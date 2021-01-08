using System;
using System.Collections.Generic;
using ChatRoom.Entity;

namespace ChatRoom.Dao
{
    public interface UserDao
    {
        List<User> FindAllUsers();
        User FindUser(string username, string password);

        User FindUser(String nickName);
        User FindUser(int uid);

        User FindUserByUsername(String username);
        
        int AddUser(User user);
        int UpdateUser(User user);
    }
}