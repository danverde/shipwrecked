using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Food : Item
    {
        public int HealingPower { get; }

        public Food(string itemType, string description, int healingPower)
            :base(itemType, description)
        {
            HealingPower = healingPower;
        }
    }
}
