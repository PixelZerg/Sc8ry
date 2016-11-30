using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public enum EquipmentType
    {
        Uknown,
        Weapon,
        Gear
    }

    public class ItemData
    { 

        public bool IsConsumable = false;
        public EquipmentType EquipmentType = EquipmentType.Uknown;
    }
}
