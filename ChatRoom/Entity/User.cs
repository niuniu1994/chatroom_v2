using System;
using SqlSugar;

namespace ChatRoom.Entity
{
    public class User
    {
        public User()
        {
            LastCallTime = DateTime.Now;
            Rid = 0;
        }

        public User(int uid, string username, string password, string nickName)
        {
            Uid = uid;
            Username = username;
            Password = password;
            NickName = nickName;
            LastCallTime = DateTime.Now;
            Rid = 0;
        }
        
        [SugarColumn( ColumnName = "user_id",IsPrimaryKey = true, IsIdentity = true)]
        public int Uid { get; set; }

        public string Username { get; set;}

        public string Password { get; set; }

        public String NickName { get; set; }

        [SugarColumn( ColumnName = "last_call_time")]
        public DateTime LastCallTime { set; get; }
        
        [SugarColumn( ColumnName = "room_id")]
        public int Rid { get; set; }
        

    }
}