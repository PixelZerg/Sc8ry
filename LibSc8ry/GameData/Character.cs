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

        public EntityType entityType
        {
            get
            {
                return EntityType.Character;
            }
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Graphics.LookSeperator(this.personalityData.Name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.personalityData.Description, 4);
            Console.ResetColor();
        } 
    }
}
