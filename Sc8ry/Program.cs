using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSc8ry;
using LibSc8ry.Framework;
using System.IO;

namespace Sc8ry
{
    class Program
    {
        //golden oak academy
        public static void Main(string[] args)
        {
            LibSc.DataModel.Gear g = new LibSc.DataModel.Gear();
            g.itemData = new LibSc.DataModel.ItemData() { IsConsumable = true, ItemId = 3849 };
            g.nd = new LibSc.DataModel.ND() { Name = "bunanna", Description = "loeoeo" };
            g.gearData = new LibSc.DataModel.GearData() { Defense = 5 };
            byte[] gb = g.GetBytes();

            LibSc.DataModel.Character c = new LibSc.DataModel.Character();
            c.charBase = new LibSc.DataModel.CharBase() { CharacterType = LibSc.Utils.CharacterType.Student, IsDead = true };
            c.emotionData = new LibSc.DataModel.EmotionData() { Anger = 15, Happiness = -4, Suicidalness = 100 };
            c.genderData = new LibSc.DataModel.GenderData() { Gender = LibSc.Utils.Gender.Thing, UseGenderEnum = true };
            c.nd = new LibSc.DataModel.ND() { Name = "Sid the FootFut", Description = "POPOPEOPEOPEOp" };
            c.personalityData = new LibSc.DataModel.PersonalityData() { Age = 75 };
            c.statData = new LibSc.DataModel.StatData() { Attack = 1, Defense = 2, Dexterity = -1, Health = 1, Reputation = -100, Speed = -5, Wisdom = -100 };
            byte[] cb = c.GetBytes();

            LibSc.ValuesParser parser = new LibSc.ValuesParser();

            parser.Parse(Utils.Combine(gb, cb));

            var s = parser.Values[LibSc.ValueType.Character][0];
        }
    }
}
