using System.Collections.Generic;
using ChatRoom.Entity;

namespace ChatRoom.Dao
{
    public interface RoomDao
    {
        List<Room> FindAllRoomsPublic();

        List<Room> FindAllRoomsPrivate(int uId);
        
        Room FindRoom(int rId);
        Room FindRoom(string name);
        int AddRoom(Room room);
        int RemoveRoom(int rId);
    }
}