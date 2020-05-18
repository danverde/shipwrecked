using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Resource : IItem
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Droppable { get; private set; }
        public Resource(string name, string description, bool droppable = true)
        {
            Name = name;
            Description = description;
            Droppable = droppable;
        }
    }
}
