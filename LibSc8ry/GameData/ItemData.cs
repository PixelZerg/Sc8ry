using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class ItemData
    {
        public enum EquipmentType
        {
            Uknown,
            None,
            Weapon,
            Gear
        }

        public bool IsConsumable = false;
        public EquipmentType Equipment = EquipmentType.None;
    }
}
