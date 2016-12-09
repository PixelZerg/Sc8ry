using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class WeaponData : IData
    {
        public int Damage = 0;
        public int Speed = 0;
        public double Accuracy = 0;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.Damage);
                bw.Write(this.Speed);
                bw.Write((int)(this.Accuracy*100));
                return Utils.AddSectionHeader(ms.ToArray(), DataType.WeaponData);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.Damage = br.ReadInt32();
                this.Speed = br.ReadInt32();
                this.Accuracy = (double)(br.ReadInt32() / 100d);
            }
        }
    }
}
