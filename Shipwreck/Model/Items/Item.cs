using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Item
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public bool Droppable { get; set; }

        public Item(string name, string description, bool droppable = true)
        {
            Name = name;
            Description = description;
            Droppable = droppable;
        }
    }
}
