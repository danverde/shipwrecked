using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Gear: Item
    {
        public Gear(string name, string description, bool droppable = true)
            : base(name, description, droppable)
        { }
    }
}
