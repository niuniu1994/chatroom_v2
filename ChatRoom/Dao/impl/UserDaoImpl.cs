using System;
using System.Collections.Generic;
using System.Linq;
using ChatRoom.Dao.utils;
using ChatRoom.Entity;
using SqlSugar;

namespace ChatRoom.Dao
{
    public class UserDaoImpl : UserDao
    {
        private SqlSugarClient db;

        public UserDaoImpl()
        {
            db = DataBaseUtil.GetInstance();
        }
        
        public List<User> FindAllUsers()
        {
            return db.Queryable<User>().ToList();
        }

        public User FindUser(string username, string password)
        {
            return db.Queryable<User>().First(user => user.Username.Equals(username) && user.Password.Equals(password));
        }

        public User FindUser(string nickName)
        {
            return db.Queryable<User>().First(user => user.NickName.Equals(nickName));
        }

        public User FindUser(int uid)
        {
            return db.Queryable<User>().First(user => user.Uid == uid);
        }

        public User FindUserByUsername(string username)
        {
            return db.Queryable<User>().First(user => user.Username.Equals(username));
        }
        
        public int AddUser(User user)
        {
           return db.Insertable<User>(user).ExecuteCommand();
        }

        public int UpdateUser(User user)
        {
            return db.Updateable<User>(user).ExecuteCommand();
            
        }
    }
}