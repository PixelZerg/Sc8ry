using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSc8ry;
using LibSc8ry.GameData;

namespace Sc8ry
{
    class Program
    {
        public static void Main(string[] args)
        {
            Room r = new Room();
            r.name = "Cool Hall";
            r.description = "Grand windows are scattered around the large, dusty hall. The windows shimmer with brilliance.";

            Character c = new Character(new PersonalityData("A fat person", 20, "a cool fat person", new GenderData(Gender.Boy)));
            r.characters.Add(c);

            r.entities.Add(new Entity());
            r.entities.Add(new Entity("automobile", "so cool"));

            while (true)
            {
                r.Look();
                Console.WriteLine("What do you want to do?");
                switch (Graphics.GetOption("Dance", "Sleep"))
                {
                    case 0:
                        if (r.characters.Contains(c))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You dance heavily and the fat person dies due to the tremors");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("You dance like there's no-one watching!");
                        }
                        r.characters.Remove(c);
                        break;
                    case 1:
                        Console.WriteLine("You sleep....");
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine("You wake up.");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}
