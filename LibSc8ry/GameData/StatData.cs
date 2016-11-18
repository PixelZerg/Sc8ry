using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class StatData
    {
        public int Health = 0;
        public int Reputation = 0;

        public int Attack = 0;
        public int Wisdom = 0;
        public int Dexterity = 0;
        public int Defence = 0;
        public int Speed = 0;

        public EmotionData emotionData = new EmotionData();
    }
}
