using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class Thing : IEntity
    {
        public string name = "thing";
        private string description = "a very boring thing";

        public EntityType EntityType
        {
            get
            {
                return EntityType.Thing;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Description
        {
            get
            {
                return NLP.ExpandText(description, GenderData.Thing);
            }
            set
            {
                description = value;
            }
        }

        public Thing()
        {
        }

        public Thing(string name, string description)
        {
            this.name = name;
            this.Description = description;
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Graphics.LookSeperator(this.name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.Description, 4);
            Console.ResetColor();
        }

        public IEntity Clone()
        {
            Thing t = new Thing();
            t.description = this.description;
            t.name = this.name;
            return t;
        }
    }
}
