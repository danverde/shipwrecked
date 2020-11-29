namespace Shipwreck.Model.Items
{
    public class Armor: Item
    {
        public Type ArmorType { get; set; }
        public int DefensePower { get; set; }

        public Armor() {}
        public Armor(string name, string description, Type type, int defensePower, bool droppable = true )
        {
            Name = name;
            Description = description;
            ArmorType = type;
            DefensePower = defensePower;
            Droppable = droppable;
        }

        public enum Type
        {
            Suit,
            LeatherJacket
        }
    }
}
