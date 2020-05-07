using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Weapon : Item
    {
        public int AttackPower { get; }

        public Weapon(string name, string description, int attackPower, int quantity = 1, bool droppable = true)
            :base(name, description, quantity, droppable)
        {
            AttackPower = attackPower;
        }
    }
}
