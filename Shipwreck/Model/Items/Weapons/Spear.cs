using System.Collections.Generic;

namespace Shipwreck.Model.Items.Weapons
{
    class Spear : Weapon, ICraftable
    {
        public static Dictionary<string, int> RequiredItems
        {
            get
            {
                return new Dictionary<string, int>
                {
                    { "Branch", 1},
                    { "Sharp Stone", 3 },
                    { "Vine", 5},
                };
            }
        }

        public override int AttackPower { get; }
        public Spear()
            :base("Spear", "Hunting Spear")
        {
            AttackPower = 4;
        }
    }
}
