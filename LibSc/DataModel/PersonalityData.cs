using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class PersonalityData : IData
    {
        public int Age = -1;

        public byte[] GetBytes()
        {
            return Utils.AddSectionHeader(BitConverter.GetBytes((Int32)this.Age), DataType.PersonalityData);
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.Age = br.ReadInt32();
            }
        }
    }
}
