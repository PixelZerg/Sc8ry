using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.Framework
{
    public enum EntityType
    {
        Thing,
        Character,
        Item
    }

    public interface IEntity
    {
        void Look();
        string Name { get; }
        string Description { get; }

        EntityType EntityType { get; }

        IEntity Clone();
    }
}
