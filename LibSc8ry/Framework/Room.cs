using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class Room
    {
        public string name = "Room";
        public string description = "A bare, empty, room.";

        public List<IEntity> entities = new List<IEntity>();

        public Room()
        {
        }

        public Room(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void Remove(IEntity e)
        {
            this.entities.Remove(e);
        }

        public IEntity Find(string str, out int dist)
        {
            int minDist = int.MaxValue;
            IEntity minMatch = null;

            foreach (IEntity entity in entities)
            {
                int cdist = Utils.LevenshteinDistance(entity.Name.ToLower(), str.ToLower());
                if (minDist > cdist)
                {
                    minDist = cdist;
                    minMatch = entity;
                }
            }
            dist = minDist;
            return minMatch;
        }

        public IEntity Find(string str, int selDist = 1)
        {
            foreach (IEntity entity in entities)
            {
                if (Utils.LevenshteinDistance(entity.Name.ToLower(), str.ToLower()) <= selDist)
                {
                    return entity;
                }
            }
            return null;
        }

        public IEntity FindExact(string str)
        {
            foreach (IEntity entity in entities)
            {
                if (entity.Name.ToLower() == str.ToLower())
                {
                    return entity;
                }
            }
            return null;
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Graphics.LookSeperator(this.name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Graphics.PrintPadded(this.description, 4);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Graphics.PrintPadded("In this room:", 4);
            foreach (IEntity entity in entities)
            {
                switch (entity.EntityType)
                {
                    case EntityType.Character:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Graphics.PrintSpace(4);
                        break;
                    case EntityType.Thing:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Graphics.PrintPaddedN(NLP.Article(entity.Name, true), 5);
                        break;
                    case EntityType.Item:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Graphics.PrintPaddedN(NLP.Article(entity.Name, true), 5);
                        break;
                }
                Console.WriteLine(" "+entity.Name,5);

            }
            Console.ResetColor();
        }

        public Room Clone()
        {
            Room r = new Room();
            r.name = this.name;
            r.description = this.description;
            foreach (IEntity e in entities)
            {
                r.entities.Add(e.Clone());
            }
            return r;
        }
    }
}
