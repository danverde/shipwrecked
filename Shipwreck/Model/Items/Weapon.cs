using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    abstract class Weapon : Gear
    {
        public abstract int AttackPower { get; }

        public Weapon(string name, string description, bool droppable = true)
            :base(name, description, droppable)
        {}
    }
}
