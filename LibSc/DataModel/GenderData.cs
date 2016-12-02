using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class GenderData : IData
    {
        public bool UseGenderEnum = true;
        public ushort Gender = 0;

        public string Pronoun = null;
        public string PronounGenitive = null;
        public string PronounAcc = null;
        public string PronounReflexive = null;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.UseGenderEnum);

                if (UseGenderEnum)
                {
                    bw.Write((ushort)this.Gender);
                }
                else
                {
                    bw.Write(Utils.StrToBytes(this.Pronoun));
                    bw.Write(Utils.StrToBytes(this.PronounGenitive));
                    bw.Write(Utils.StrToBytes(this.PronounAcc));
                    bw.Write(Utils.StrToBytes(this.PronounReflexive));
                }
                return Utils.AddSectionHeader(ms.ToArray(), DataType.GenderData);
            }
        }
    }
}
