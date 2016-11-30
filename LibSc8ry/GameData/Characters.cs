using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Characters
    {
        public Framework.Character pooTeacher = new LibSc8ry.Framework.Character();
        public LibSc8ry.Framework.Character mathTeacher = new LibSc8ry.Framework.Character();
        public Framework.Character Iapnes = new Framework.Character();

        public void Load()
        {
            this.LoadDefault();
        }

        private void LoadDefault()
        {
            pooTeacher.personalityData.Name = "lolpoo";
            pooTeacher.personalityData.Age = 69;
            pooTeacher.personalityData.genderData = new Framework.GenderData("poo", "per", "pim", "pooself");

            mathTeacher.personalityData.Name = "Steven Steve";
            mathTeacher.personalityData.Age = 79;
            mathTeacher.personalityData.genderData = new Framework.GenderData(Framework.Gender.Boy);
            mathTeacher.personalityData.Description = "A small dumpling disguised as a math teacher, {e} would probably roll if you gave {a} a push.";
            mathTeacher.statData.Attack = 1;
            mathTeacher.statData.Defence = 3;
            mathTeacher.statData.Dexterity = 1;
            mathTeacher.statData.Health = 50;
            mathTeacher.statData.Reputation = 2;
            mathTeacher.statData.Speed = 1;
            mathTeacher.statData.Wisdom = 3;

            Iapnes.personalityData.Name = "Sjoh";
            Iapnes.personalityData.Age = 15;
            Iapnes.personalityData.genderData = new Framework.GenderData(Framework.Gender.Boy);
            Iapnes.personalityData.Description = "Your arch rival. {E} is Satan, reincarnated as a schoolboy. {E} always get A*s and 9s, is constanly smug and apparently on the national team for literally everything, from sewing to athletics.";
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
