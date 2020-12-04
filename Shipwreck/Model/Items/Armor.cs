namespace Shipwreck.Model.Items
{
    public class Armor: Item
    {
        protected override ItemType ItemType { get; } = ItemType.Armor;
        public override string StringItemType { get; } = ItemType.Armor.ToString();
        public ArmorType ArmorType { get; set; }
        public int DefensePower { get; set; }

        public Armor()
        {
            ItemType = ItemType.Armor;
        }
    }

    public enum ArmorType
    {
        Suit,
        LeatherJacket
    }
}
