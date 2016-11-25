﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
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
        EntityType entityType { get; }
    }
}
