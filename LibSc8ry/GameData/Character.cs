using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Character
    {
        public PersonalityData personalityData = null;
        public StatData statData = new StatData();

        public Character()
        {
            personalityData = new PersonalityData();
        }

        public Character(PersonalityData personalityData)
        {
            this.personalityData = personalityData;
        }
    }
}
