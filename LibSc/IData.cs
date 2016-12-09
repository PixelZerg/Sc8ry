using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc
{
    public interface IData
    {
        byte[] GetBytes();
        //void ParseBytes(byte[] bytes);
    }
}
