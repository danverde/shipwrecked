using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Fists : Weapon
    {
        public override int AttackPower { get; }

        public Fists()
            :base("Fists", "Fists of Fury")
        {
            AttackPower = 1;
        }
    }
}
