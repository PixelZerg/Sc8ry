using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    public class ConsoleRectangle
    {
        public int Width;
        public int Height;
        public GameData.Point Location;
        public ConsoleColor BorderColour;
        public ConsoleColor fillColour;

        public string Text = "";

        public ConsoleRectangle(string text, int width, int hieght, GameData.Point location, ConsoleColor borderColour, ConsoleColor fillColour)
        {
            this.Text = text;
            this.Width = width;
            this.Height = hieght;
            this.Location = location;
            this.BorderColour = borderColour;
            this.fillColour = fillColour;
        }

        public void Draw(string fill = " ")
        {
            if (this.Location.Y+this.Height >= Console.WindowHeight)
            {
                return;
            }
            try
            {
                Console.CursorTop = this.Location.Y;
                Console.CursorLeft = this.Location.X;
            }
            catch
            {
                return;
            }
            Console.ForegroundColor = this.BorderColour;


            //string s = "┌";
            Console.Write("┌");
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += fill;
                //s += "─";
                Console.Write("─");
            }

            for (int j = 0; j < Location.X; j++)
            {
                temp += " ";
            }

            //s += "┐" + "\n";
            Console.WriteLine("┐");

            string[] textSplit = Utils.ChunksUpto(Text, this.Width - 0).ToArray();

            for (int i = 0; i < Height; i++)
            {
                //s += temp + "│" + space + "│" + "\n";
                Console.ForegroundColor = fillColour;
                //Console.Write(temp);
                Console.CursorLeft = Location.X;
                Console.ForegroundColor = this.BorderColour;
                Console.Write("│");
                Console.ForegroundColor = fillColour;
                if (i < Height - 1)
                {
                    try
                    {
                        Console.Write(Utils.PadOrTruncate(textSplit[i], Width - 0, fill));
                    }
                    catch
                    {
                        Console.Write(space);
                    }
                }
                else
                {
                    if (i == textSplit.Length - 1)
                    {
                        Console.Write(Utils.PadOrTruncate(textSplit[i], Width - 0, fill));
                    }
                    else if (textSplit.Length > Height)
                    {
                        Console.Write(Utils.PadOrTruncate(textSplit[i] + " ", Width - 0, fill));
                    }
                    else
                    {
                        Console.Write(space);
                    }
                }
                Console.ForegroundColor = this.BorderColour;
                Console.WriteLine("│");
            }

            //Console.ba = fillColour;
            //s += temp + "└";
            //Console.Write(temp);
            Console.CursorLeft = Location.X;
            Console.ForegroundColor = this.BorderColour;
            Console.Write("└");

            Console.ForegroundColor = this.BorderColour;
            for (int i = 0; i < Width; i++)
            {
                //s += "─";
                Console.Write("─");
            }

            //s += "┘" + "\n";
            Console.WriteLine("┘");

            Console.ResetColor();
        }
    }
}
