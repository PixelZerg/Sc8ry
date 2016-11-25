using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Entity
    {
        public string name = "thing";
        public string description = "a very boring thing";

        public Entity()
        {
        }

        public Entity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Graphics.LookSeperator(this.name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.description,4);
            Console.ResetColor();
        }
    }
}
