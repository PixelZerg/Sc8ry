using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class StatData : IData
    {
        public int Health = 0;
        public int Reputation = 0;
        public int Attack = 0;
        public int Wisdom = 0;
        public int Dexterity = 0;
        public int Defense = 0;
        public int Speed = 0;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.Health);
                bw.Write(this.Reputation);
                bw.Write(this.Attack);
                bw.Write(this.Wisdom);
                bw.Write(this.Dexterity);
                bw.Write(this.Defense);
                bw.Write(this.Speed);
                return Utils.AddSectionHeader(ms.ToArray(), DataType.StatData);
            }
        }
    }
}
