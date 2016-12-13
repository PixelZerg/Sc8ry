using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class Weapon : IItem
    {
        private ND _nd = new ND();
        private ItemData _itemData = new ItemData();
        public WeaponData weaponData = new WeaponData();

        public ND nd { get { return _nd; } set { _nd = value; } }
        public ItemData itemData { get { _itemData.ItemType = Utils.ItemType.Weapon; return _itemData; } set { _itemData = value; } }

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(_nd.GetBytes());
                bw.Write(_itemData.GetBytes());
                bw.Write(weaponData.GetBytes());
                return Utils.AddMainHeader(ms.ToArray(), ValueType.Weapon);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            SectionsParser mp = new SectionsParser();
            mp.Parse(bytes);

            this._nd = (ND)mp.Sections[DataType.ND];
            this._itemData = (ItemData)mp.Sections[DataType.ItemData];
            this.weaponData = (WeaponData)mp.Sections[DataType.WeaponData];
        }
    }
}
