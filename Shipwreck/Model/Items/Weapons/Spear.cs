using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Spear : Weapon, ICraftable
    {
        public Dictionary<string, int> RequiredItems { get; }

        public override int AttackPower { get; }
        public Spear()
            :base("Spear", "Hunting Spear")
        {
            AttackPower = 4;
            RequiredItems = new Dictionary<string, int>
            {
                {"Branch", 1},
                {"Sharp Stone", 3 },
                {"Vine", 5 }
            };
        }
    }
}
