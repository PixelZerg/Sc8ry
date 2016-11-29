using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class Character : IEntity
    {
        public PersonalityData personalityData = null;
        public StatData statData = new StatData();

        /// <summary>
        /// The first 2 slots is for Weapon and Gear and the rest is for item storage
        /// </summary>
        public IItem[] Slots = new IItem[12];

        public Character()
        {
            personalityData = new PersonalityData();
        }

        public Character(PersonalityData personalityData)
        {
            this.personalityData = personalityData;
        }

        //TODO: Add character.JoinRoom(room). Keep list of rooms. Also add Character.Kill() which will remove it from all rooms

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
            for (int i = 0; i < this.Slots.Length; i++)
            {
                try
                {
                    c.Slots[i] = this.Slots[i].Clone();
                }
                catch { }
            }
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
