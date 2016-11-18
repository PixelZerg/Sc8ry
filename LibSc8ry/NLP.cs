using LibSc8ry.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry
{
    public static class NLP
    {
        public static string ExpandText(string input, GenderData genderData)
        {
            return input.Replace("{s}", genderData.PronounGenitive).Replace("{e}", genderData.Pronoun);
        }
    }
}
