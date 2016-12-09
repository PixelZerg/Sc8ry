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

        ND IItem.nd { get { return _nd; } set { _nd = value; } }
        ItemData IItem.itemData { get { return _itemData; } set { _itemData = value; } }

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
    }
}
