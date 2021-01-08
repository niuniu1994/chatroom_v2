using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using ChatRoom.Dao;
using ChatRoom.Dto;
using ChatRoom.Entity;
using Newtonsoft.Json;

namespace ChatRoom.Service.impl
{
    public class UserServiceImpl : IUserService
    {
        private UserDao _userDao;
        private RoomDao _roomDao;


        public UserServiceImpl(UserDao userDao, RoomDao roomDao)
        {
            _userDao = userDao;
            _roomDao = roomDao;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.FindAllUsers();
        }

        public User GetLoginUser(string username, string password)
        {
            return _userDao.FindUser(username, password);
        }

        public Boolean AddUser(User user)
        {
            if (user != null)
            {
                user.Rid = 1;

                int res = _userDao.AddUser(user);
                if (res != 1)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool CheckUserNickname(string nickname)
        {
            return _userDao.FindUser(nickname) != null ? true : false;
        }

        public User FindUserByNickname(string nickname)
        {
            return _userDao.FindUser(nickname);
        }

        public User FindUserByUsername(string username)
        {
            return _userDao.FindUserByUsername(username);
        }

        public void InformUser(int uid, int rid, WebsocketResponse response)
        {
            Room room = _roomDao.FindRoom(rid);
            String username = null;
            String responseStr = null;
            
            
            if ("private".Equals(room.Type))
            {
                response.Type = "pri_chat";
                if (uid.Equals(room.Owner))
                {
                    username = _userDao.FindUser(uid).Username;
                    response.Message = $"---------- {username} are waiting for you in room {room.Name} ---------- ";
                    responseStr = JsonConvert.SerializeObject(response);
                    SendMessage(room.Guest, responseStr);
                }
                else
                {
                    username = _userDao.FindUser(room.Guest).Username;
                    response.Message = $"---------- {username} are waiting for you in room {room.Name} ---------- ";
                    responseStr = JsonConvert.SerializeObject(response);
                    SendMessage(room.Owner, responseStr);
                }
            }
            else
            {
                response.Type = "pub_chat";
                responseStr = JsonConvert.SerializeObject(response);
                SendMessage(uid, responseStr);
            }
        }

        public void SendMessage(int uid, string msg)
        {
            var message = Encoding.UTF8.GetBytes(msg);
            WebSocket webSocket = WebSocketPool.Get(uid);
            webSocket.SendAsync(new ArraySegment<byte>(message, 0, msg.Length), WebSocketMessageType.Text, true,
                CancellationToken.None);
        }

        public void SendMessageToRoom(int rid, String msg)
        {
            var message = Encoding.UTF8.GetBytes(msg);
            List<WebSocket> _list = WebSocketPool.GetWebSocketsByRoom(rid);
            _list.ForEach((webSocket) => webSocket.SendAsync(new ArraySegment<byte>(message, 0, msg.Length),
                WebSocketMessageType.Text, true, CancellationToken.None));
        }
    }
}