using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc8ry
{
    public class GameState
    {
        public static int Chapter = 1;

        public static FileInfo saveFile = new FileInfo("gamedata.dat");

        public static void Save()
        {
            using (StreamWriter sw = new StreamWriter(saveFile.FullName))
            {
                sw.WriteLine(Chapter.ToString());
            }
        }

        public static void Load()
        {
            if (!saveFile.Exists)
            {
                saveFile.Create();
                Save();
                return;
            }
            string[] s = File.ReadAllLines(saveFile.FullName);
            try
            {
                Chapter = Int32.Parse(s[0]);
            }
            catch { }


        }
    }
}
