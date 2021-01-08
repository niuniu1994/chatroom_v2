using System;
using System.Collections.Generic;
using ChatRoom.Entity;

namespace ChatRoom.Service
{
    public interface IRoomService
    {

        IEnumerable<Room> GetAllRoomsPublic();

        IEnumerable<Room> GetAllRoomsPrivate(int uId);
        void AddRoom(Room room);
        
        Boolean CheckRoomName(string name);
        
    }
}