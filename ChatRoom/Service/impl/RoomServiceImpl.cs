using System;
using System.Collections.Generic;
using ChatRoom.Dao;
using ChatRoom.Entity;

namespace ChatRoom.Service.impl
{
    public class RoomServiceImpl: IRoomService
    {
        private RoomDao _roomDao;

        public RoomServiceImpl(RoomDao roomDao)
        {
            _roomDao = roomDao;
        }

        public IEnumerable<Room> GetAllRoomsPublic()
        {
            return _roomDao.FindAllRoomsPublic();
        }


        public bool CheckRoomName(string name)
        {
            return _roomDao.FindRoom(name) == null ? false : true;
        }

        public IEnumerable<Room> GetAllRoomsPrivate(int uId)
        {
            return _roomDao.FindAllRoomsPrivate(uId);
        }

        public void AddRoom(Room room)
        {
            _roomDao.AddRoom(room);
        }
    }
}