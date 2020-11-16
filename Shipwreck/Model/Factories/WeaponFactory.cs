using Shipwreck.Model.Items.Weapons;

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
                    weapon = new Spear();
                    break;
                case "fists":
                    weapon = new Fists();
                    break;
            }

            return weapon;
        }
    }
}
