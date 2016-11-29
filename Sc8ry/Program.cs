using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSc8ry;
using LibSc8ry.Framework;

namespace Sc8ry
{
    class Program
    {
        public static void Main(string[] args)
        {
            Room r = new Room();
            r.name = "Cool Hall";
            r.description = "Grand windows are scattered around the large, dusty hall. The windows shimmer with brilliance.";

            Character c = new Character(new PersonalityData("Sushant", 20, "A cool fat person. {S} majestic rolls of fat bounce as the air particles surrounding {a} bounce into {a}. NB: {e} never cleans {r}.", GenderData.Boy));
            r.entities.Add(c);

            r.entities.Add(new Thing());
            r.entities.Add(new Thing("automobile", "{E} is so cool, man!!!"));

            Map map = new Map();
            map.AddRoom(r, 0, 0);
            map.AddRoom(r.Clone(), 0, 1);
            map.AddRoom(r.Clone(), 0, 2);
            map.AddRoom(new Room("BANANA ROOM",""), 1, 2);
            map.AddRoom(r.Clone(), 2, 2);
            map.AddRoom(new Room("you have a banana, you have a banana and you have a banana"," "), 2, 3);
            map.AddRoom(r.Clone(), 2, 1);
            map.AddRoom(new Room("the guildy guild room"," "), 0, 3);
            map.AddRoom(r.Clone(), 0, 4);
            map.AddRoom(r.Clone(), -1, 4);
            map.AddRoom(new Room("a", ""), -2, 4);
            map.AddRoom(new Room("e", ""), -3, 4);
            map.AddRoom(new Room("i", ""), -4, 4);
            map.AddRoom(new Room("moo",""), -4, 5);

            map.Display(r);
            while (true)
            {
                r.Look();
                Console.WriteLine("What do you want to do?");
                switch (Graphics.GetOption("Dance", "Sleep"))
                {
                    case 0:
                        if (r.entities.Contains(c))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You dance heavily and " + c.Name + " dies due to the tremors");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("You dance like there's no-one watching!");
                        }
                        r.entities.Remove(c);
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
