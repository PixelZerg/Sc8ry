using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class GenderData
    {
        public string Pronoun = "he";
        public string PronounGenitive = "his";

        public GenderData() { }
        public GenderData(Gender gender)
        {
            switch (gender)
            {
                case Gender.Boy:
                    return;
                case Gender.Girl:
                    this.Pronoun = "she";
                    this.PronounGenitive = "her";
                    return;
                case Gender.Unkown:
                    this.Pronoun = "it";
                    this.PronounGenitive = "its";
                    return;
            }
        }
        public GenderData(string pronoun, string pronounGenitive)
        {
            this.Pronoun = pronoun;
            this.PronounGenitive = pronounGenitive;
        }
    }
}
