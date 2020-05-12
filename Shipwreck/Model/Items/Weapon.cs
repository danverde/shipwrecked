using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Weapon : Gear
    {
        public int AttackPower { get; }

        public Weapon(string name, string description, int attackPower, bool droppable = true)
            :base(name, description, droppable)
        {
            AttackPower = attackPower;
        }
    }
}
