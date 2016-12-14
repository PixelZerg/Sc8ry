using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class GenderData
    {
        public static GenderData Boy = new GenderData(LibSc.Utils.Gender.Boy);
        public static GenderData Girl = new GenderData(LibSc.Utils.Gender.Girl);
        public static GenderData Thing = new GenderData(LibSc.Utils.Gender.Thing);

        private LibSc.DataModel.GenderData data = new LibSc.DataModel.GenderData(LibSc.Utils.Gender.Boy);

        public string Pronoun { get; private set; }
        public string PronounGenitive { get; private set; }
        public string PronounAcc { get; private set; }
        public string PronounReflexive { get; private set; }

        public GenderData()
        {
            this.data.UseGenderEnum = false;

            this.Pronoun = "";
            this.PronounAcc = "";
            this.PronounGenitive = "";
            this.PronounReflexive = "";
        }
        public GenderData(LibSc.Utils.Gender gender)
        {
            switch (gender)
            {
                case LibSc.Utils.Gender.Boy:
                    this.data.UseGenderEnum = true;
                    this.data.Gender = gender;

                    this.Pronoun = "he";
                    this.PronounGenitive = "his";
                    this.PronounAcc = "him";
                    this.PronounReflexive = "himself";
                    return;
                case LibSc.Utils.Gender.Girl:
                    this.data.UseGenderEnum = true;
                    this.data.Gender = gender;

                    this.Pronoun = "she";
                    this.PronounGenitive = "her";
                    this.PronounAcc = "her";
                    this.PronounReflexive = "herself";
                    return;
                case LibSc.Utils.Gender.Thing:
                    this.data.UseGenderEnum = true;
                    this.data.Gender = gender;

                    this.Pronoun = "it";
                    this.PronounGenitive = "its";
                    this.PronounAcc = "it";
                    this.PronounReflexive = "itself";
                    return;
            }

            this.data.UseGenderEnum = false;
            this.data.Gender = gender;

            this.Pronoun = "";
            this.PronounAcc = "";
            this.PronounGenitive = "";
            this.PronounReflexive = "";
        }



        public GenderData(string pronoun, string pronounGenitive, string pronounAcc, string pronounReflexive)
        {
            this.data.UseGenderEnum = false;

            this.Pronoun = pronoun;
            this.PronounGenitive = pronounGenitive;
            this.PronounAcc = pronounAcc;
            this.PronounReflexive = pronounReflexive;

            this.data.Pronoun = pronoun;
            this.data.PronounGenitive = pronounGenitive;
            this.data.PronounAcc = pronounAcc;
            this.data.PronounReflexive = pronounReflexive;
        }

        public GenderData Clone()
        {
            GenderData r = null;
            //r.Pronoun = this.Pronoun;
            //r.PronounAcc = this.PronounAcc;
            //r.PronounGenitive = this.PronounGenitive;
            //r.PronounReflexive = this.PronounReflexive;
            if (this.data.UseGenderEnum)
            {
                r = new GenderData(this.data.Gender);
            }
            else
            {
                r = new GenderData(this.Pronoun, this.PronounGenitive, this.PronounAcc, this.PronounReflexive);
            }
            return r;
        }
    }
}
