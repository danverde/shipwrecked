using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        public bool Droppable { get; }
    }
}
