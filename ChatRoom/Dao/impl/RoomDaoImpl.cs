using System.Collections.Generic;
using ChatRoom.Dao.utils;
using ChatRoom.Entity;
using SqlSugar;

namespace ChatRoom.Dao
{
    public class RoomDaoImpl : RoomDao
    {
        private SqlSugarClient db;

        public RoomDaoImpl()
        {
            this.db = DataBaseUtil.GetInstance();
        }

        public List<Room> FindAllRoomsPublic()
        {
            return db.Queryable<Room>().Where(room => room.Type.Equals("public")).ToList();
        }

        public List<Room> FindAllRoomsPrivate(int uId)
        {
            return db.Queryable<Room>().Where(room => room.Type.Equals("private") && (room.Owner == uId || room.Guest == uId)).ToList();
        }

        public Room FindRoom(int rId)
        {
            return db.Queryable<Room>().First(room => room.Rid == rId);
        }

        public Room FindRoom(string name)
        {
            return db.Queryable<Room>().First(room => room.Name.Equals(name));
        }

        public int AddRoom(Room room)
        {
            return db.Insertable<Room>(room).ExecuteCommand();
        }

        public int RemoveRoom(int rId)
        {
            return db.Deleteable<Room>().In(rId).ExecuteCommand();
        }
    }
}