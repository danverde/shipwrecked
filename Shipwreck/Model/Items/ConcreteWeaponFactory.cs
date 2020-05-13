﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shipwreck.Model.Items
{
    class ConcreteWeaponFactory: WeaponFactory
    {
        public override Weapon GetWeapon(string weaponType)
        {
            weaponType = weaponType.ToLower();
            Weapon weapon;
            switch(weaponType)
            {
                case "spear":
                    weapon = new Spear();
                    break;
                case "fists":
                    weapon = new Fists();
                    break;
                default:
                    throw new Exception($"Unable to create {weaponType}. It is not a valid weapon");
            }

            return weapon;
        }
    }
}
