using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Armor: Gear
    {
        public int DefensePower { get; }

        public Armor(string name, string description, int defensePower, bool droppable = true)
            :base(name, description, droppable)
        {
            DefensePower = defensePower;
        }
    }
}
