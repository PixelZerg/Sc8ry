using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSc8ry;
using LibSc8ry.Framework;
using System.IO;

namespace Sc8ry
{
    class Program
    {
        //golden oak academy
        public static void Main(string[] args)
        {
            //LibSc.DataModel.CharBase c = new LibSc.DataModel.CharBase();
            //c.CharacterType = LibSc.Utils.CharacterType.Parent;
            //c.IsDead = false;
            //c.Slots[0] = 10;
            //c.Slots[1] = 9;
            //c.Slots[2] = 8;
            //c.Slots[3] = 7;
            //c.Slots[4] = 2;
            //c.Slots[5] = 1;
            //c.Slots[6] = 699;
            //c.Slots[7] = 42;

            //byte[] cbin = c.GetBytes();
            //LibSc.DataModel.CharBase c2 = new LibSc.DataModel.CharBase();

            //using (MemoryStream ms = new MemoryStream(cbin))
            //using (BinaryReader br = new BinaryReader(ms))
            //{
            //    int len = br.ReadInt32();
            //    ushort type = br.ReadUInt16();
            //    c2.ParseBytes(br.ReadBytes(len-2));
            //}

            LibSc.DataModel.Gear g = new LibSc.DataModel.Gear();
            new LibSc.MainParser().Parse(g.GetBytes());

        }
    }
}
