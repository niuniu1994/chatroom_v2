using System;
using ChatRoom.Entity;

namespace ChatRoom.Dto
{
    public class WebSocketMessage
    {
        public User Sender{ set; get; }

        public string action { set; get; }
        
        public string msg { get; set; }
    }
}