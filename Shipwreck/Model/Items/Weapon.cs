namespace Shipwreck.Model.Items
{
    public class Weapon : Item
    {
        protected override ItemType ItemType { get; } = ItemType.Weapon;
        public override string StringItemType { get; } = ItemType.Weapon.ToString();
        public WeaponType WeaponType { get; set; }
        public int AttackPower { get; set; }
        
        public Weapon()
        {
            ItemType = ItemType.Weapon;
        }
    }

    public enum WeaponType
    {
        Spear,
        Fists
    }
}
