using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public enum CharacterType
    {
        Teacher,
        Student,
        Parent,
        Other
    }

    public class Character : IEntity
    {
        public bool IsDead { get; private set; }

        public PersonalityData personalityData = null;
        public StatData statData = new StatData();

        // TODO: replace with index
        public Room curRoom = null;

        public CharacterType characterType = CharacterType.Other;

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

        public void JoinRoom(Room room)
        {
            this.LeaveRoom();
            curRoom = room;
            curRoom.entities.Add(this);
        }

        public void LeaveRoom()
        {
            if (curRoom != null)
            {
                curRoom.entities.Remove(this);
            }
        }

        public void Kill()
        {
            this.LeaveRoom();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.Name + " died");
            Console.ResetColor();
            this.IsDead = true;
        }

        public void KillSilent()
        {
            this.LeaveRoom();
            this.IsDead = true;
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

        public string Description
        {
            get
            {
                return this.personalityData.Description;
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

            Console.ForegroundColor = ConsoleColor.Magenta;
            Graphics.PrintPadded(NLP.ExpandText("{E} has:", this.personalityData.genderData), 4);
            for (int i = 0; i < this.Slots.Length;i++)
            {
                if (this.Slots[i] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    try
                    {
                        switch (this.Slots[i].ItemData.EquipmentType)
                        {
                            case EquipmentType.Weapon:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case EquipmentType.Gear:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                        }
                    }
                    catch { }

                    Graphics.PrintPaddedN(" " + NLP.Article(this.Slots[i].Name, true)+" "+ this.Slots[i].Name, 5);
                    if (i == 0)
                    {
                        Console.Write(NLP.ExpandText(" ({s} weapon)", this.personalityData.genderData));
                    }
                    else if (i == 1)
                    {
                        Console.Write(NLP.ExpandText(" ({s} gear)", this.personalityData.genderData));
                    }
                    Console.WriteLine();
                }
                else
                {
                    if (i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Graphics.PrintPadded("<No weapon>", 5);
                    }
                    else if (i == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Graphics.PrintPadded("<No gear>", 5);

                    }
                }
            }
            Console.ResetColor();
        }
    }
}