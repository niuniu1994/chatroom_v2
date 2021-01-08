using System.Collections.Generic;
using ChatRoom.Entity;

namespace ChatRoom.Dto
{
    public class ChatRoomInitModel
    {
        private IEnumerable<Room> publicRooms = null;

        private IEnumerable<Room> privateRooms = null;

        public IEnumerable<Room> PublicRooms
        {
            get => publicRooms;
            set => publicRooms = value;
        }

        public IEnumerable<Room> PrivateRooms
        {
            get => privateRooms;
            set => privateRooms = value;
        }
    }
}