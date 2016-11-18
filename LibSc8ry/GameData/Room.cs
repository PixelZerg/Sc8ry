using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Room
    {
        public string name = "Room";
        public string description = "A bare, empty, room.";

        public List<Entity> entities = new List<Entity>();
        public List<Character> characters = new List<Character>();

        public Room()
        {
        }

        public Room(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
