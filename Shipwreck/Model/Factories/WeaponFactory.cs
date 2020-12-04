using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class WeaponFactory
    {
        public Weapon GetWeapon(WeaponType weaponType)
        {
            var weapon = new Weapon
            {
                Droppable = true
            };
            
            switch(weaponType)
            {
                case WeaponType.Spear:
                    weapon.Name = "Spear";
                    weapon.Description = "Hunting Spear";
                    weapon.AttackPower = 4;
                    break;
                case WeaponType.Fists:
                    weapon.Name = "Fists";
                    weapon.Description = "Fists of Fury";
                    weapon.AttackPower = 1;
                    weapon.Droppable = false;
                    break;
            }
        
            return weapon;
        }
    }
}
