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
        public Utils.Gender Gender = 0;

        public string Pronoun = null;
        public string PronounGenitive = null;
        public string PronounAcc = null;
        public string PronounReflexive = null;

        public GenderData()
        {
        }

        public GenderData(Utils.Gender gender)
        {
            this.UseGenderEnum = true;
            this.Gender = gender;
        }

        public GenderData(string pronoun, string pronounGenitive, string pronounAcc, string pronounReflexive)
        {
            this.UseGenderEnum = false;
            this.Pronoun = pronoun;
            this.PronounGenitive = pronounGenitive;
            this.PronounAcc = pronounAcc;
            this.PronounReflexive = pronounReflexive;
        }

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

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.UseGenderEnum = br.ReadBoolean();
                if (this.UseGenderEnum)
                {
                    this.Gender = (Utils.Gender)br.ReadUInt16();
                }
                else
                {
                    this.Pronoun = Utils.ReadStr(br);
                    this.PronounGenitive = Utils.ReadStr(br);
                    this.PronounAcc = Utils.ReadStr(br);
                    this.PronounReflexive = Utils.ReadStr(br);
                }
            }
        }
    }
}
