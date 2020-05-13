using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Resource : Item
    {
        public Resource(string name, string description, bool droppable = true)
            :base(name, description, droppable)
        { }
    }
}
