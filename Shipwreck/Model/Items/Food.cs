using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Food : Item
    {
        public int HealingPower { get; }
        public int FillingPower { get;  }

        public Food(string itemType, string description, int healingPower, int fillingPower)
            :base(itemType, description)
        {
            HealingPower = healingPower;
            FillingPower = fillingPower;
        }
    }
}
