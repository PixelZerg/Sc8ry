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
        public List<DataModel.ND> NDSections = new List<DataModel.ND>();
        public List<DataModel.CharBase> CharBaseSections = new List<DataModel.CharBase>();
        public List<DataModel.GenderData> GenderDataSections = new List<DataModel.GenderData>();
        public List<DataModel.PersonalityData> PersonalityDataSections = new List<DataModel.PersonalityData>();
        public List<DataModel.EmotionData> EmotionDataSections = new List<DataModel.EmotionData>();
        public List<DataModel.StatData> StatDataSections = new List<DataModel.StatData>();
        public List<DataModel.ItemData> ItemDataSections = new List<DataModel.ItemData>();
        public List<DataModel.WeaponData> WeaponDataSections = new List<DataModel.WeaponData>();
        public List<DataModel.GearData> GearDataSections = new List<DataModel.GearData>();

        private int byteCount = -1;
        public int Type = -1;

        public void Parse(byte[] bytes, bool HeaderIncluded = true)
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
                using (MemoryStream ms = new MemoryStream(section))
                using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
                {
                    DataType dataType = (DataType)br.ReadUInt16();
                    byte[] data = br.ReadBytes(section.Length - 2);
                }
            }
        }

        private List<byte[]> Split(byte[] bytes)
        {
            List<byte[]> ret = new List<byte[]>();

            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                int remaining = bytes.Length;
                while (remaining > 0) // {In32 (4)} + {UInt16 (2)}
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
