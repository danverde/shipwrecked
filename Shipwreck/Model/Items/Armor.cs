namespace Shipwreck.Model.Items
{
    public class Armor: Item
    {
        public override ItemType ItemType { get; } = ItemType.Armor;
        public override string StringItemType { get; } = "Armor";
        public ArmorType ArmorType { get; set; }
        public int DefensePower { get; set; }
    }

    public enum ArmorType
    {
        Suit,
        LeatherJacket
    }
}
