namespace Shipwreck.Model.Items
{
    public class Weapon : Item
    {
        public override ItemType ItemType { get; } = ItemType.Weapon;
        public WeaponType WeaponType { get; set; }
        public int AttackPower { get; set; }
    }

    public enum WeaponType
    {
        Spear,
        Fists
    }
}
