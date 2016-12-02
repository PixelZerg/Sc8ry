using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class ND : IData
    {
        public string Name = "";
        public string Description = "";

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(Utils.StrToBytes(this.Name));
                bw.Write(Utils.StrToBytes(this.Description));

                return Utils.AddSectionHeader(ms.ToArray(), DataType.ND);
            }
        }
    }
}
