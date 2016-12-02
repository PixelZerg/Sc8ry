using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
