using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace ChatRoom.Entity
{
    public class WebSocketPool
    {
        public static Dictionary<User, WebSocket> WebSocketPoolDict = new Dictionary<User, WebSocket>();

        public static void Add(User user, WebSocket webSocket)
        {
            WebSocketPoolDict.Add(user, webSocket);
        }

        public static void Remove(User user)
        {
            WebSocketPoolDict.Remove(user);
        }

        public static WebSocket Get(int uid)
        {
            return WebSocketPoolDict.FirstOrDefault((item) =>
                item.Key.Uid == uid
            ).Value;
        }

        public static Dictionary<User, WebSocket> WebSocketPoolDict1
        {
            get => WebSocketPoolDict;
            set => WebSocketPoolDict = value;
        }

        public static List<WebSocket> GetWebSocketsByRoom(int rid)
        {
            List<WebSocket> webSockets = new List<WebSocket>();
            foreach (var item in WebSocketPoolDict)
            {
                if (rid == item.Key.Rid)
                {
                    webSockets.Add(item.Value);
                }
            }
            return webSockets;
        }
    }
}