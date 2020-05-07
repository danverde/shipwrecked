using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Armor: Item
    {
        public int DefensePower { get; }

        public Armor(string name, string description, int defensePower)
            :base(name, description)
        {
            DefensePower = defensePower;
        }
    }
}
