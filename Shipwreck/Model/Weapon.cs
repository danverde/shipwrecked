using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Weapon : Item
    {
        public int AttackPower { get; }

        public Weapon(string name, int attackPower = 1)
            :base(name)
        {
            AttackPower = attackPower;
        }
    }
}
