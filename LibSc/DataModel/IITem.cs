using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public interface IItem : IData
    {
        ND nd
        {
            get; set;
        }
        ItemData itemData
        {
            get; set;
        }
    }
}
