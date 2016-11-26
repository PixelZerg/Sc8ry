using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class EmotionData
    {
        public int Happiness = 0;
        public int Anger = 0;
        public int Sucidalness = 0;

        public EmotionData Clone()
        {
            EmotionData e = new EmotionData();
            e.Happiness = this.Happiness;
            e.Anger = this.Anger;
            e.Sucidalness = this.Sucidalness;
            return e;
        }
    }
}
