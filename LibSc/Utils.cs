using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc
{
    public enum DataType
    {
        ND,
        CharBase,
        GenderData,
        PersonalityData,
        EmotionData,
        StatData,
        ItemData,
        WeaponData,
        GearData
    }
    public enum ValueType
    {
        Setting,
        Thing,
        Character,
        Item,
        Weapon,
        Gear
    }
    public class Utils
    {
        public static byte[] StrToBytes(string str)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write((Int32)Encoding.UTF8.GetByteCount(str));
                bw.Write(Encoding.UTF8.GetBytes(str));
                return ms.ToArray();
            }
        }

        public static byte[] AddSectionHeader(byte[] b, DataType dataType)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(b.Length + 2);
                bw.Write((ushort)dataType);
                bw.Write(b);
                return ms.ToArray();
            }
        }

        public static byte[] AddMainHeader(byte[] b, ValueType valueType)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(b.Length + 2);
                bw.Write((ushort)valueType);
                bw.Write(b);
                return ms.ToArray();
            }
        }
    }
}
