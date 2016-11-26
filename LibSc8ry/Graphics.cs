using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    public static class Graphics
    {
        public static void DisplayOptions(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + args[i]);
            }
        }

        public static int GetOption(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + args[i]);
            }
            return ReadNumber(args.Length.ToString().Length)-1;
        }

        public static int ReadNumber(int maxlength = 5)
        {
            string _val = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (_val.Length < maxlength)
                {
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        double val = 0;
                        bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                        if (_x)
                        {
                            _val += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                        {
                            _val = _val.Substring(0, (_val.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.Write(Environment.NewLine);

            return Int32.Parse(_val);
        }

        public static void LookSeperator(string name)
        {
            ConsoleUtils.PrintSeperator(name, '-', '<','>');
        }

        public static void PrintPadded(string str, int space, bool trim = true)
        {
            foreach (string s in str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                List<string> chunks = Utils.ChunksUpto(s, Console.WindowWidth - (space+1)).ToList();
                foreach (string chunk in chunks)
                {
                    PrintSpace(space);
                    string chunkk = (trim) ? chunk.Trim() : chunk;
                    Console.WriteLine(chunkk);
                }
            }
        }

        public static void PrintPaddedN(string str, int space, bool trim = true)
        {
            foreach (string s in str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                List<string> chunks = Utils.ChunksUpto(s, Console.WindowWidth - (space + 1)).ToList();
                foreach (string chunk in chunks)
                {
                    PrintSpace(space);
                    string chunkk = (trim) ? chunk.Trim() : chunk;
                    Console.Write(chunkk);
                }
            }
        }

        public static void PrintSpace(int no)
        {
            for (int i = 0; i < no; i++)
            {
                Console.Write(" ");
            }
        }

        public static void PrintRect()
        {
        }
    }
}