using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatRoom.Dto;
using ChatRoom.Entity;

namespace ChatRoom.Service
{
    public interface IUserService
    {
        void SendMessage(int uid,string msg);
        void SendMessageToRoom(int rid, string msg);

        IEnumerable<User> GetAllUsers();

        User GetLoginUser(string username, string password);

        Boolean AddUser(User user);

        Boolean CheckUserNickname(String nickname);

        User FindUserByNickname(String nickname);

        User FindUserByUsername(String username);

        void InformUser(int uid, int rid,WebsocketResponse response);
        
        
        
        
    }
}