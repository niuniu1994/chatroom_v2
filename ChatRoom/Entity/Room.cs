using System;
using System.Collections.Generic;
using SqlSugar;

namespace ChatRoom.Entity
{
    public class Room
    {
        public Room(int rid, string name)
        {
            Rid = rid;
            Name = name;
        }

        public Room()
        {
        }

        public override bool Equals(object? obj)
        {
            if ( obj != null && obj.GetType().Equals(this.GetType()))
            {
                Room _room = (Room) obj;
                return this.Name.Equals(_room.Name);
            }
            return false;
        }

        [SugarColumn( ColumnName = "room_id",IsPrimaryKey = true, IsIdentity = true)]
        public int Rid { get; set; }
        public string Name { get; set; }
        
        //private room or public room
        public string Type { get; set; }
        
        public int Owner { get; set; }
        
        public int Guest { get; set; }

    }
}