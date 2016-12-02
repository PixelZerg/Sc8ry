using System;
using System.Collections.Generic;
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

        ND IItem.nd { get { return _nd; } set { _nd = value; } }
        ItemData IItem.itemData { get { return _itemData; } set { _itemData = value; } }
    }
}
