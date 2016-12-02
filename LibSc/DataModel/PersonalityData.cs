using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class PersonalityData : IData
    {
        public int Age = -1;

        public byte[] GetBytes()
        {
            return Utils.AddSectionHeader(BitConverter.GetBytes((Int32)this.Age), DataType.PersonalityData);
        }
    }
}
