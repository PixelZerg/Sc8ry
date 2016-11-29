using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
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
            AddRoom(r,new Point(x, y*-1), ov);
        }

        public void Display(Room curRoom)
        {
            Display(rooms.FirstOrDefault(x => x.Value == curRoom).Key);
        }

        public void Display(Point curRoom)
        {
            int zoom = 5;
            int lzoom = 5;
            int offx = 0;
            int loffx = 0;
            int offy = 0;
            int loffy = 0;

            while (true)
            {
                //ConsoleUtils.Clear();
                ClearRender(curRoom, loffx, loffy, lzoom);
                loffx = offx;
                loffy = offy;
                lzoom = zoom;
                Render(curRoom, offx, offy, zoom);

                Console.CursorTop = Console.WindowHeight;
                Console.CursorLeft = 0;
                Console.Write("Use the arrow keys to navigate, Z and X to zoom and press ENTER to exit");

                Console.ForegroundColor = Console.BackgroundColor;
                ConsoleKeyInfo k = Console.ReadKey();
                Console.ResetColor();
                if (k.Key == ConsoleKey.UpArrow)
                {
                    offy-=2;
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    offy+=2;
                }

                if (k.Key == ConsoleKey.LeftArrow)
                {
                    offx-=2;
                }
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    offx+=2;
                }

                if (k.Key == ConsoleKey.Z)
                {
                    zoom++;
                }
                else if (k.Key == ConsoleKey.X)
                {
                    if (zoom > 1)
                    {
                        zoom--;
                    }
                }

                if (k.Key == ConsoleKey.Enter)
                {
                    ConsoleUtils.Clear();
                    break;
                }
            }
        }

        internal void Render(Point curRoom, int offx, int offy, int zoom)
        {
            Point centre = new Point((Console.WindowWidth / 2) - zoom, (Console.WindowHeight / 2) - zoom / 2);

            try
            {
                int offsetx = (curRoom.X * -1) + centre.X;
                int offsety = (curRoom.Y * -1) + centre.Y;

                foreach (var room in rooms)
                {
                    new ConsoleRectangle(room.Value.name, zoom * 2, zoom, new Point(
                    (centre.X + (((room.Key.X + offsetx) - centre.X) * (zoom * 2 + 2))) + offx,
                    (centre.Y + ((room.Key.Y + offsety) - centre.Y) * (zoom + 2)) + offy
                    ), ((room.Key != curRoom) ? ConsoleColor.Blue : ConsoleColor.Cyan), ConsoleColor.Gray
                    ).Draw();
                }
            }
            catch
            {
                Console.Write("X");
            }
        }

        internal void ClearRender(Point curRoom, int offx, int offy, int zoom)
        {
            Point centre = new Point((Console.WindowWidth / 2) - zoom, (Console.WindowHeight / 2) - zoom / 2);
            int offsetx = (curRoom.X * -1) + centre.X;
            int offsety = (curRoom.Y * -1) + centre.Y;

            foreach (var room in rooms)
            {
                new ConsoleRectangle(room.Value.name, zoom * 2, zoom, new Point(
                (centre.X + (((room.Key.X + offsetx) - centre.X) * (zoom * 2 + 2))) + offx,
                (centre.Y + ((room.Key.Y + offsety) - centre.Y) * (zoom + 2)) + offy
                ), (Console.BackgroundColor), Console.BackgroundColor
                ).Draw(" ");
            }
        }
    }
}
