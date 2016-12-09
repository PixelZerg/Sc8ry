using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc
{
    public class MainParser
    {
        //Sections
        public Dictionary<LibSc.DataType, LibSc.IData> Sections = new Dictionary<DataType, IData>();

        private int byteCount = -1;
        public int Type = -1;

        public void Parse(byte[] bytes, bool HeaderIncluded = false)
        {
            byte[] raw = null;
            if (HeaderIncluded)
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
                {
                    this.byteCount = br.ReadInt32();
                    this.Type = (Int32)br.ReadUInt16();
                    raw = br.ReadBytes(byteCount - 2); //maybe -4 too
                }
            }
            else
            {
                raw = bytes;
            }
            List<byte[]> sections = Split(raw);

            foreach (var section in sections)
            {
                ParseSection(section);
            }
        }

        /// <summary>
        ///  No length - just dataType in header
        /// </summary>
        public void ParseSection(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                DataType dataType = (DataType)br.ReadUInt16();
                byte[] rawdata = br.ReadBytes(bytes.Length - 2);

                IData data = (IData)Activator.CreateInstance(GetClassType(dataType));
                data.ParseBytes(rawdata);

                if (this.Sections.ContainsKey(dataType))
                {
                    this.Sections.Remove(dataType);
                }
                this.Sections.Add(dataType, data);
            }
        }

        public static Type GetClassType(DataType d)
        {
            switch (d)
            {
                case DataType.CharBase:
                    return typeof(LibSc.DataModel.CharBase);
                case DataType.EmotionData:
                    return typeof(LibSc.DataModel.EmotionData);
                case DataType.GearData:
                    return typeof(LibSc.DataModel.GearData);
                case DataType.GenderData:
                    return typeof(LibSc.DataModel.GenderData);
                case DataType.ItemData:
                    return typeof(LibSc.DataModel.ItemData);
                case DataType.ND:
                    return typeof(LibSc.DataModel.ND);
                case DataType.PersonalityData:
                    return typeof(LibSc.DataModel.PersonalityData);
                case DataType.StatData:
                    return typeof(LibSc.DataModel.StatData);
                case DataType.WeaponData:
                    return typeof(LibSc.DataModel.WeaponData);
            }
            return null;
        }

        private List<byte[]> Split(byte[] bytes)
        {
            List<byte[]> ret = new List<byte[]>();

            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                int remaining = bytes.Length;
                while (remaining > 6) // {In32 (4)} + {UInt16 (2)}
                {
                    //Section Header
                    int len = br.ReadInt32();


                    byte[] raw = new byte[len];
                    br.Read(raw, 0, len);
                    ret.Add(raw);

                    remaining -= (len + 4); //Int32
                }
            }

            return ret;
        }
    }
}
