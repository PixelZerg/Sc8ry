using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class ItemData : IData
    {
        public Int32 ItemId = 0;
        public bool IsConsumable = false;
        public Utils.ItemType ItemType = 0;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.ItemId);
                bw.Write(this.IsConsumable);
                bw.Write((ushort)this.ItemType);
                return Utils.AddSectionHeader(ms.ToArray(), DataType.ItemData);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.ItemId = br.ReadInt32();
                this.IsConsumable = br.ReadBoolean();
                this.ItemType = (Utils.ItemType)br.ReadUInt16();
            }
        }
    }
}
