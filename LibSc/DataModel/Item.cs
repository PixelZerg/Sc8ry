using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class Item : IItem
    {
        private ND _nd = new ND();
        private ItemData _itemData = new ItemData();

        public ND nd { get { return _nd; } set { _nd = value; } }
        public ItemData itemData { get { _itemData.ItemType = Utils.ItemType.Item; return _itemData; } set { _itemData = value; } }

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(_nd.GetBytes());
                bw.Write(_itemData.GetBytes());
                return Utils.AddMainHeader(ms.ToArray(), ValueType.Item);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            MainParser mp = new MainParser();
            mp.Parse(bytes);

            this._nd = (ND)mp.Sections[DataType.ND];
            this._itemData = (ItemData)mp.Sections[DataType.ItemData];
        }
    }
}
