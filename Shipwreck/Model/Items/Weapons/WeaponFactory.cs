using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    abstract class WeaponFactory
    {
        public abstract Weapon GetWeapon(string weaponType);
    }
}
