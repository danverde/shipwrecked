namespace Shipwreck.Model.Items
{
    public class Armor: IGear
    {
        public string Name { get; }
        public string Description { get; }
        public Type ArmorType { get; }
        public int DefensePower { get; }
        public bool Droppable { get; }

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
