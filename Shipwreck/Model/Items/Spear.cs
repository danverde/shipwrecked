using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Spear : Weapon
    {
        // Maybe create some sort of buildable class that stores the material requirements?
        // this could be useful, but I'd have to figure out how to sort my inventory by parent Types as well as Type...
        public Spear()
            :base("Spear", "Hunting Spear", 4)
        { }
    }
}
