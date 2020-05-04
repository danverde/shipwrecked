using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Food : Item
    {
        public int HealingPower { get; }

        public Food(string itemType, int healingPower)
            :base(itemType)
        {
            HealingPower = healingPower;
        }
    }
}
