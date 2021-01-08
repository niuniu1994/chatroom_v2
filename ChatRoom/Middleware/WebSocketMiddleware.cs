using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatRoom.Dto;
using ChatRoom.Entity;
using ChatRoom.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ChatRoom
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public WebSocketMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            IUserService _userService
        )
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<WebSocketMiddleware>();
            this._userService = _userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userSession = context.Session.GetString("user");
            User user = userSession != null
                ? JsonConvert.DeserializeObject<User>(context.Session.GetString("user"))
                : null;

            if (context.Request.Path == "/ws" && user != null)
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    try
                    {
                        await WebsocketHandler(webSocket, user);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, "Echo websocket user {0} err .", user.Uid);
                        await context.Response.WriteAsync("closed");
                    }
                } else
                {
                    context.Response.StatusCode = 404;
                }
            }
            else
            {
                await _next(context);
            }
        }

        private async Task WebsocketHandler(WebSocket webSocket, User user)
        {
            WebSocketPool.Remove(user);
            WebSocketPool.Add(user, webSocket);
            _logger.LogInformation($"{user.Username} get connected with WebSocket" );
            WebSocketReceiveResult result = null;
            
            do
            {
                var buffer = new byte[1024 * 1];
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text && !result.CloseStatus.HasValue)
                {
                    user.LastCallTime = DateTime.Now;
                    var msgString = Encoding.UTF8.GetString(buffer);
                    _logger.LogInformation($"user {user.Uid} ReceiveAsync message {msgString}.");
                    WebSocketMessage msg = JsonConvert.DeserializeObject<WebSocketMessage>(msgString);
                    msg.Sender = user;
                    WebSocketRoute(msg);
                }
            } while (!result.CloseStatus.HasValue);

            WebSocketPool.Remove(user);
            _logger.LogInformation($"{user.Uid} has closed his connection");
        }

        private async Task WebSocketRoute(WebSocketMessage msg)
        {
            WebsocketResponse response = new WebsocketResponse();
            String responseStr = null;
            
            switch (msg.action)
            {
                case "join":
                    int rid;
                    if (int.TryParse(msg.msg, out rid))
                    {
                        msg.Sender.Rid = rid;
                        
                        response.Message = $"{msg.Sender.NickName} has successfully joined room ";
                        _userService.InformUser(msg.Sender.Uid,msg.Sender.Rid,response);
              
                        _logger.LogInformation($"user {msg.Sender.Uid} joined room");
                    }

                    break;
                case "send":
                    if (msg.Sender.Rid <= 0)
                    {
                        break;
                    }
                    response = new WebsocketResponse();
                    response.Message = $"{msg.Sender.NickName} : {msg.msg}";
                    response.Type = "chat";
                    responseStr = JsonConvert.SerializeObject(response);
                    _userService.SendMessageToRoom(msg.Sender.Rid, responseStr);
                    _logger.LogInformation($"user {msg.Sender.Uid} send '{msg.msg}' to room {msg.Sender.Rid}");
                    break;

                case "leave":
                    msg.Sender.Rid = 0;
                    response.Message = $"{msg.Sender.NickName} left room {msg.Sender.Rid}";
                    response.Type = "chat";
                    responseStr = JsonConvert.SerializeObject(response);
                    _userService.SendMessage(msg.Sender.Uid, responseStr);
                    _logger.LogInformation($"user {msg.Sender.Uid} left room {msg.Sender.Rid}");
                    break;
                default:
                    break;
            }
        }
    }
}