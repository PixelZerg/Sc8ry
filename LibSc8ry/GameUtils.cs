using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    public static class GameUtils
    {
        public static void PrintText(string textt)
        {
            string text = Graphics.WordBreakText(textt);

            int no = 0;
            while (!Console.KeyAvailable && no < text.Length)
            {
                Console.Write(text[no]);
                System.Threading.Thread.Sleep(25);
                no++;
            }
            if (no < text.Length)
            {
                Console.Write(text.Substring(no, text.Length - no));
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
