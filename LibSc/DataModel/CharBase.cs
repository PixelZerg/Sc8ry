using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class CharBase : IData
    {
        public bool IsDead = false;
        public Utils.CharacterType CharacterType = 0;
        public Int32[] Slots = new Int32[12];

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.IsDead);
                bw.Write((ushort)this.CharacterType);
                for (int i = 0; i < 12; i++)
                {
                    bw.Write((Int32)Slots[i]);
                }
                return Utils.AddSectionHeader(ms.ToArray(), DataType.CharBase);
            }
        }
    }
}
