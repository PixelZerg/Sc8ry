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
            return input.Replace("{s}", genderData.PronounGenitive).Replace("{e}", genderData.Pronoun)
                .Replace("{S}", Capitalise(genderData.PronounGenitive)).Replace("{E}", Capitalise(genderData.Pronoun))
                .Replace("{a}", genderData.PronounAcc).Replace("{r}", genderData.PronounReflexive)
                .Replace("{A}", Capitalise(genderData.PronounAcc)).Replace("{R}", Capitalise(genderData.PronounReflexive))
                ;
        }

        public static string Capitalise(string s)
        {
            return s[0].ToString().ToUpper() + s.Substring(1, s.Length - 1);
        }

        public static string Article(string thing, bool capitalise = false)
        {
            if (thing.ToLower().StartsWith("a"))
            {
                return (capitalise)?"An":"an";
            }
            return (capitalise) ? "A" : "a";
        }
    }
}
