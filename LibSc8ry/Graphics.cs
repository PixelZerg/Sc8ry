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
            return ReadNumber(args.Length.ToString().Length);
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

        public static void LookDialogue(string name, string desc)
        {
            ConsoleUtils.PrintSeperator(name, '-', '<','>');

            foreach (string s in desc.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                List<string> chunks = Utils.ChunksUpto(s, Console.WindowWidth - 5).ToList();
                foreach (string chunk in chunks)
                {
                    Console.WriteLine("    " + chunk);
                }
            }
        }
    }
}