﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public class PersonalityData
    {
        public string Name = "noname";
        public int Age = -1;

        /// <summary>
        /// {s} = his/her/its
        /// {e} = he/she/it
        /// </summary>
        private string description = "{s} emotionless face is vacant";

        public GenderData genderData = new GenderData(Gender.Thing);

        public string Description
        {
            get
            {
                return NLP.ExpandText(description, genderData);
            }
            set
            {
                description = value;
            }
        }

        public PersonalityData()
        {
        }

        public PersonalityData(string name, int age, string description, GenderData genderData)
        {
            this.Name = name;
            this.Age = age;
            this.Description = description;
            this.genderData = genderData;
        }

        public PersonalityData Clone()
        {
            PersonalityData d = new PersonalityData();
            d.Age = this.Age;
            d.description = this.description;
            d.genderData = this.genderData.Clone();
            d.Name = this.Name;
            return d;
        }
    }
}
