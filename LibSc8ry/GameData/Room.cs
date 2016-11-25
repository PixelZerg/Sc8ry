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

        public List<IEntity> entities = new List<IEntity>();

        public Room()
        {
        }

        public Room(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void Remove(IEntity e)
        {
            this.entities.Remove(e);
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Graphics.LookSeperator(this.name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.description, 4);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //foreach (Character character in characters)
            //{
            //    Graphics.PrintPadded(character.personalityData.Name + " is here", 5);
            //}
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //foreach (IEntity entity in entities)
            //{
            //    Graphics.PrintPadded(NLP.Article(entity.name,true)+" "+entity.name+ " is here", 5);
            //}//TODO
            Console.ResetColor();
        }
    }
}
