﻿using System;
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
    

    public static class Utils
    {
        public enum ItemType
        {
            Item,
            Weapon,
            Gear,
        }
        public enum CharacterType
        {
            Teacher,
            Student,
            Parent,
            Other
        }
        public enum Gender
        {
            Thing,
            Boy,
            Girl,
            Other,
        }

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

        public static string ReadStr(BinaryReader br)
        {
            int len = br.ReadInt32();
            byte[] raw = new byte[len];
            br.Read(raw, 0, len);
            return Encoding.UTF8.GetString(raw);
        }

        public static byte[] AddSectionHeader(byte[] b, DataType dataType)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write((Int32)(b.Length + 2));
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
                bw.Write((Int32)(b.Length + 2));
                bw.Write((ushort)valueType);
                bw.Write(b);
                return ms.ToArray();
            }
        }

        public static byte[] StripHeader(byte[] b)
        {
            //Int32 + Ushort
            return b.SubArray(6, b.Length - 6);
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
