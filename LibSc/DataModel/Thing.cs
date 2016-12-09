using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class Thing : IData
    {
        public ND nd = new ND();

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.nd.GetBytes());
                return Utils.AddMainHeader(ms.ToArray(), ValueType.Thing);
            }
        }
    }
}
