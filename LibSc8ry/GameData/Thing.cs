using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Thing : IEntity
    {
        public string name = "thing";
        public string description = "a very boring thing";

        public EntityType entityType
        {
            get
            {
                return EntityType.Thing;
            }
        }

        public Thing()
        {
        }

        public Thing(string name, string description)
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
            Graphics.PrintPadded(this.description, 4);
            Console.ResetColor();
        }
    }
}
