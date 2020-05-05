using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Weapon : Item
    {
        public int AttackPower { get; }

        public Weapon(string name, string description, int attackPower = 1)
            :base(name, description)
        {
            AttackPower = attackPower;
        }
    }
}
