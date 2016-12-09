using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class Gear : IItem
    {
        private ND _nd = new ND();
        private ItemData _itemData = new ItemData();
        public GearData gearData = new GearData();

        public ND nd { get { return _nd; } set { _nd = value; } }
        public ItemData itemData { get { _itemData.ItemType = Utils.ItemType.Gear; return _itemData; } set { _itemData = value; } }

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(_nd.GetBytes());
                bw.Write(_itemData.GetBytes());
                bw.Write(gearData.GetBytes());
                return Utils.AddMainHeader(ms.ToArray(), ValueType.Gear);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            MainParser mp = new MainParser();
            mp.Parse(bytes);

            this._nd = (ND)mp.Sections[DataType.ND];
            this._itemData = (ItemData)mp.Sections[DataType.ItemData];
            this.gearData = (GearData)mp.Sections[DataType.GearData];
        }
    }
}
