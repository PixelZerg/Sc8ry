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
            LibSc.DataModel.Gear g = new LibSc.DataModel.Gear();
            g.itemData = new LibSc.DataModel.ItemData() { IsConsumable = true, ItemId = 3849 };
            g.nd = new LibSc.DataModel.ND() { Name = "bunanna", Description = "loeoeo" };
            g.gearData = new LibSc.DataModel.GearData() { Defense = 5 };
            byte[] b = g.GetBytes();

            LibSc.DataModel.Gear g2 = new LibSc.DataModel.Gear();
            g2.ParseBytes(LibSc.Utils.SubArray<byte>(b, 6, b.Length - 6));
        }
    }
}
