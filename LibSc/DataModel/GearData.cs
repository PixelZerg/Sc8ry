using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class GearData : IData
    {
        public int Defense = 0;

        public byte[] GetBytes()
        {
            return Utils.AddSectionHeader(BitConverter.GetBytes((Int32)this.Defense), DataType.GearData);
        }
    }
}
