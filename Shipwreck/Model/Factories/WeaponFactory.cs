using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class WeaponFactory
    {
        public Weapon GetWeapon(string weaponType)
        {
            weaponType = weaponType.ToLower();
            Weapon weapon = null;
            switch(weaponType)
            {
                case "spear":
                    weapon = new Weapon
                    {
                        Name = "Spear",
                        Description = "Hunting Spear",
                        AttackPower = 4,
                        Droppable = true
                    };
                    break;
                case "fists":
                    weapon = new Weapon
                    {
                        Name = "Fists",
                        Description = "Fists of Fury",
                        AttackPower = 1,
                        Droppable = false
                    };
                    break;
            }

            return weapon;
        }
    }
}
