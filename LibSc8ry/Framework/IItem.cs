using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public interface IItem
    {
        ItemData ItemData { get; set; }

        string Name { get; }
        string Description { get; }

        IItem Clone();
    }
}
