using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc
{
    public class ValuesParser
    {
        //values
        public Dictionary<LibSc.ValueType, List<LibSc.IData>> Values = new Dictionary<ValueType, List<IData>>();

        public void Parse(byte[] bytes)
        {
            List<byte[]> raw = Split(bytes);

            foreach (byte[] section in raw)
            {
                this.ParseSection(section);
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
                ValueType valueType = (ValueType)br.ReadUInt16();
                byte[] rawdata = br.ReadBytes(bytes.Length - 2);

                IData data = (IData)Activator.CreateInstance(GetClassType(valueType));
                data.ParseBytes(rawdata);

                if (!this.Values.ContainsKey(valueType))
                {
                    this.Values.Add(valueType, new List<IData>());
                }
                this.Values[valueType].Add(data);
            }
        }

        private Type GetClassType(ValueType valueType)
        {
            switch (valueType)
            {
                case ValueType.Character:
                    return typeof(LibSc.DataModel.Character);
                case ValueType.Gear:
                    return typeof(LibSc.DataModel.Gear);
                case ValueType.Item:
                    return typeof(LibSc.DataModel.Item);
                case ValueType.Setting:
                    throw new NotImplementedException("Setting value type is not implemented");
                case ValueType.Thing:
                    return typeof(LibSc.DataModel.Thing);
                case ValueType.Weapon:
                    return typeof(LibSc.DataModel.Weapon);
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
