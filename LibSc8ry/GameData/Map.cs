using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Map
    {
        public Dictionary<Point, Room> rooms = new Dictionary<Point, Room>();

        /// <param name="ov">Wether it will replace a room if it already exists at that point or not</param>
        public void AddRoom(Room r, Point p, bool ov = true)
        {
            if (!rooms.ContainsKey(p) || ov)
            {
                if (rooms.ContainsKey(p))
                {
                    rooms.Remove(p);
                }
                rooms.Add(p, r);
            }
        }

        /// <param name="ov">Wether it will replace a room if it already exists at that point or not</param>
        public void AddRoom(Room r, int x, int y, bool ov = true)
        {
            AddRoom(r,new Point(x, y), ov);
        }

        public void Display(Room curRoom)
        {
            Display(rooms.FirstOrDefault(x => x.Value == curRoom).Key);
        }

        public void Display(Point curRoom)
        {
            Render(curRoom, new Point(curRoom.X,curRoom.Y), 5);
        }

        public void Render(Point curRoom, Point focus, int zoom)
        {
            //Console.ReadKey();
            //int centrex = Console.WindowWidth/2;
            //int centrey = Console.WindowHeight/2;
            //int offx = (centre.X * (zoom)) -centrex;
            //int offy = (centre.Y * (zoom));// - centrey;

            //Point p = new Point(0, 0);
            //new ConsoleRectangle("t", zoom, zoom, new Point(Console.WindowWidth - zoom / 2 + (p.X*zoom + offx), centrey+(p.Y*zoom)+offy), ConsoleColor.White, ConsoleColor.White).Draw();

            //p = new Point(0, 1);
            //new ConsoleRectangle("t", zoom, zoom, new Point(Console.WindowWidth - zoom / 2 + (p.X * zoom + offx), centrey + (p.Y * zoom)+offy), ConsoleColor.White, ConsoleColor.White).Draw();

            //int offx = (Console.WindowWidth / 2)- (zoom/2)+2;
            //int offy = (Console.WindowHeight / 2) - (zoom / 2)+2;

            //Point p = new Point(1, 1);
            //new ConsoleRectangle("1,1", zoom, zoom/3, new Point((p.X*(zoom+2))+offx,(p.Y*(zoom/3+2))+offy), ConsoleColor.White, ConsoleColor.White).Draw();

            //p = new Point(0, 2);
            //new ConsoleRectangle("0,2", zoom, zoom/3, new Point((p.X * (zoom+2)) + offx, (p.Y * (zoom/3+2)) + offy), ConsoleColor.White, ConsoleColor.White).Draw();


            //p = new Point(1, 0);
            //new ConsoleRectangle("1,0", zoom, zoom/3, new Point((p.X * (zoom + 2)) + offx, (p.Y * (zoom/3 + 2)) + offy), ConsoleColor.White, ConsoleColor.White).Draw();

            //p = new Point(0, 0);
            //new ConsoleRectangle("0,0", zoom, zoom/3, new Point((p.X * (zoom + 2)) + offx, (p.Y * (zoom/3 + 2)) + offy), ConsoleColor.White, ConsoleColor.White).Draw();

            //p = new Point(0, 1);
            //new ConsoleRectangle("0,1", zoom, zoom/3, new Point((p.X * (zoom + 2)) + offx, (p.Y * (zoom/3 + 2)) + offy), ConsoleColor.White, ConsoleColor.White).Draw();

            Point centre = new Point((Console.WindowWidth / 2)-zoom, (Console.WindowHeight / 2)-zoom/2);
            int offsetx = (focus.X * -1) + centre.X;
            int offsety = (focus.Y * -1) + centre.Y;

            Point p;

            p = new Point(1, 0);
            new ConsoleRectangle("1,0", zoom*2, zoom, new Point(
                centre.X + (((p.X + offsetx) - centre.X) * (zoom*2 + 2)),
                centre.Y + ((p.Y + offsety) - centre.Y) * (zoom + 2)
                ), ConsoleColor.Red, ConsoleColor.White
                ).Draw();

            p = new Point(0, 0);
            new ConsoleRectangle("0,0", zoom*2, zoom, new Point(
                centre.X + (((p.X + offsetx) - centre.X) * (zoom*2+2)),
                centre.Y + ((p.Y + offsety) - centre.Y) * (zoom+2)
                ), ConsoleColor.Red, ConsoleColor.White
                ).Draw();

            p = new Point(0, 1);
            new ConsoleRectangle("0,1", zoom*2, zoom, new Point(
                centre.X + (((p.X + offsetx) - centre.X) * (zoom*2+2)),
                centre.Y + ((p.Y + offsety) - centre.Y) * (zoom+2)
                ), ConsoleColor.Red, ConsoleColor.White
                ).Draw();
        }
    }
}
