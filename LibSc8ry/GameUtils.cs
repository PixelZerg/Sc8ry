using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    public class GameUtils
    {
        public void PrintText(string text)
        {
            int no = 0;
            while (!Console.KeyAvailable && no < text.Length)
            {
                //Console.Write()
                no++;
            }
        }
    }
}
