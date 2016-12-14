using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class Character : IEntity
    {
        public LibSc.DataModel.Character charData = new LibSc.DataModel.Character();

        public Character()
        {
        }

        public Character(LibSc.DataModel.Character charData)
        {
            this.charData = charData;
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
                return this.charData.nd.Name;
            }
        }

        public string Description
        {
            get
            {
                return this.charData.nd.Description;
            }
        }

        public IEntity Clone()
        {
            LibSc.DataModel.Character newc = new LibSc.DataModel.Character();
            newc.ParseBytes(LibSc.Utils.StripHeader(this.charData.GetBytes()));
            return new Character(newc);
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Graphics.LookSeperator(this.Name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.charData.nd.Description, 4);
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