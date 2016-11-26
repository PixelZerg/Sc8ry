using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Character : IEntity
    {
        public PersonalityData personalityData = null;
        public StatData statData = new StatData();

        public Character()
        {
            personalityData = new PersonalityData();
        }

        public Character(PersonalityData personalityData)
        {
            this.personalityData = personalityData;
        }

        public EntityType EntityType
        {
            get
            {
                return EntityType.Character;
            }
        }

        public string Name
        {
            get
            {
                return this.personalityData.Name;
            }
        }

        public IEntity Clone()
        {
            Character c = new Character();
            c.personalityData = this.personalityData.Clone();
            c.statData = this.statData.Clone();
            return c;
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Graphics.LookSeperator(this.Name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.personalityData.Description, 4);
            Console.ResetColor();
        } 
    }
}
