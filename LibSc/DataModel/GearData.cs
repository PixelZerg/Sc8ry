using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class GearData : IData
    {
        public int Defense = 0;

        public byte[] GetBytes()
        {
            return Utils.AddSectionHeader(BitConverter.GetBytes((Int32)this.Defense), DataType.GearData);
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.Defense = br.ReadInt32();
            }
        }
    }
}
