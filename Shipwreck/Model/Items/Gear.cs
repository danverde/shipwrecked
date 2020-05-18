using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Gear: IItem
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Droppable { get; private set; }
        public Gear(string name, string description, bool droppable = true)
        {
            Name = name;
            Description = description;
            Droppable = droppable;
        }
    }
}
