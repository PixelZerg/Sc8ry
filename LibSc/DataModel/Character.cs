using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class Character : IData
    {
        public ND nd = new ND();
        public CharBase charBase = new CharBase();

        public PersonalityData personalityData = new PersonalityData();
        public GenderData genderData = new GenderData();
        public EmotionData emotionData = new EmotionData();
        public StatData statData = new StatData();

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(nd.GetBytes());
                bw.Write(charBase.GetBytes());
                bw.Write(personalityData.GetBytes());
                bw.Write(genderData.GetBytes());
                bw.Write(emotionData.GetBytes());
                bw.Write(statData.GetBytes());

                return Utils.AddMainHeader(ms.ToArray(), ValueType.Character);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            SectionsParser mp = new SectionsParser();
            mp.Parse(bytes);

            this.nd = (ND)mp.Sections[DataType.ND];
            this.charBase = (CharBase)mp.Sections[DataType.CharBase];
            this.personalityData = (PersonalityData)mp.Sections[DataType.PersonalityData];
            this.genderData = (GenderData)mp.Sections[DataType.GenderData];
            this.emotionData = (EmotionData)mp.Sections[DataType.EmotionData];
            this.statData = (StatData)mp.Sections[DataType.StatData];
        }
    }
}
