using System;
using System.Collections.Generic;
using System.Linq;
using ChatRoom.Entity;
using SqlSugar;

namespace ChatRoom.Dao.utils
{
    public class DataBaseUtil
    {
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=localhost;Database=CHATROOMDB;Uid=root;Pwd=86537161;min pool size = 10;max pool size=20",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                                  db.Utilities.SerializeObject(
                                      pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}