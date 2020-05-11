using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Weapon : Gear
    {
        public int AttackPower { get; }

        public Weapon(string name, string description, int attackPower, bool droppable = true)
            :base(name, description, droppable)
        {
            AttackPower = attackPower;
        }

        public enum WeaponTypes
        {
            Fists,
            Staff,
            Club,
            Hatchet,
            Spear,
            Pistol
        }
    }
}
