using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class GenderData
    {
        public static GenderData Boy = new GenderData(Gender.Boy);
        public static GenderData Girl = new GenderData(Gender.Girl);
        public static GenderData Thing = new GenderData(Gender.Unkown);

        public string Pronoun = "he";
        public string PronounGenitive = "his";
        public string PronounAcc = "him";
        public string PronounReflexive = "himself";

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
                    this.PronounAcc = "her";
                    this.PronounReflexive = "herself";
                    return;
                case Gender.Unkown:
                    this.Pronoun = "it";
                    this.PronounGenitive = "its";
                    this.PronounAcc = "it";
                    this.PronounReflexive = "itself";
                    return;
            }
        }
        public GenderData(string pronoun, string pronounGenitive, string pronounAcc, string pronounReflexive)
        {
            this.Pronoun = pronoun;
            this.PronounGenitive = pronounGenitive;
            this.PronounAcc = pronounAcc;
            this.PronounReflexive = pronounReflexive;
        }

        public GenderData Clone()
        {
            GenderData r = new GenderData();
            r.Pronoun = this.Pronoun;
            r.PronounAcc = this.PronounAcc;
            r.PronounGenitive = this.PronounGenitive;
            r.PronounReflexive = this.PronounReflexive;
            return r;
        }
    }
}
