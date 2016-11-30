using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSc8ry.Framework;

namespace LibSc8ry.GameData.Weapons
{
    public class Biro : IItem, IWeapon
    {
        public string Description
        {
            get
            {
                return "A long thin biro pen usually used for writing.";
            }
        }

        private ItemData itemData = new ItemData() { EquipmentType = EquipmentType.Weapon, IsConsumable = false };

        public string Name
        {
            get
            {
                return "Coolpen";
            }
        }

        public ItemData ItemData
        {
            get
            {
                return itemData;
            }

            set
            {
                itemData = value;
            }
        }

        public WeaponData data
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IItem Clone()
        {
            Biro b = new Biro();
            return b;
        }
    }
}
