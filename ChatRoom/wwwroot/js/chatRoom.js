let server = 'ws://localhost:5001'; 

let WEB_SOCKET = new WebSocket(server + '/ws');

WEB_SOCKET.onopen = function (evt) {
    console.log('Connection open ...');
    $('#msgList').val('websocket connection opened .');
};

WEB_SOCKET.onclose = function (evt) {
    console.log('Connection closed.');
};

WEB_SOCKET.onmessage = function (evt) {
    console.log(evt.data);
    
    if (evt.data) {
        let content = $('#msgList').val();
        let jsonData = JSON.parse(evt.data);
        if (jsonData[1] === 'pri_chat'){
            content = content + '<span style="color: red">' + jsonData.Message + '</span>'; 
        }else {
            content = content + '\r\n' + jsonData.Message + '\r\n';
        }
        $('#msgList').val(content);
    }
};

$('.chatRoom').click(function (event) {
        let roomNo = event.target.id;
        if (roomNo) {
            $('#msgList').val('');
            let msg = {
                action: 'join',
                msg: roomNo,
            };
            WEB_SOCKET.send(JSON.stringify(msg));
            $('#roomTitle').text(event.target.text)
        }
    }
)


$('#btnSend').on('click', function () {
    let message = $('#txtMsg').val();
    if (message) {
        WEB_SOCKET.send(JSON.stringify({
            action: 'send',
            msg: message,
        }));
    }
    $('#txtMsg').val('');
});

$('#btnLeave').on('click', function () {
    let msg = {
        action: 'leave',
        msg: '',
    };
    WEB_SOCKET.send(JSON.stringify(msg));
});


$(
    function () {
        setInterval(function () {
            let msg = {
                action: 'check',
                msg: '',
            };
            WEB_SOCKET.send(JSON.stringify(msg));
        }, 5000);
    }
)