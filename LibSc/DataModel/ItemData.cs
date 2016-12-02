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
        public ushort EquipmentType = 0;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.ItemId);
                bw.Write(IsConsumable);
                bw.Write(EquipmentType);
                return Utils.AddSectionHeader(ms.ToArray(), DataType.ItemData);
            }
        }
    }
}
