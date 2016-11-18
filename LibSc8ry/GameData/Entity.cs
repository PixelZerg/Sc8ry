using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Entity
    {
        public PersonalityData personalityData = null;
        public StatData statData = new StatData();

        public Entity()
        {
            personalityData = new PersonalityData();
        }

        public Entity(PersonalityData personalityData)
        {
            this.personalityData = personalityData;
        }
    }
}
