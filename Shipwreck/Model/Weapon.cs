using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Weapon : Item
    {
        private int AttackPower { get; }

        public Weapon(string itemType, int attackPower = 1)
            :base(itemType)
        {
            AttackPower = attackPower;
        }
    }
}
