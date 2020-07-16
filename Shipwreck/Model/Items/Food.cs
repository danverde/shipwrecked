namespace Shipwreck.Model.Items
{
    class Food : IItem
    {
        public string Name { get; }
        public string Description { get; }
        public Type FoodType { get; }
        public int HealingPower { get; }
        public int FillingPower { get; }
        public bool Droppable { get; }

        public Food(string name, string description, Type type, int healing, int hunger, bool drop = true)
        {
            Name = name;
            Description = description;
            FoodType = type;
            HealingPower = healing;
            FillingPower = hunger;
            Droppable = drop;
        }

        public enum Type 
        {
            Banana,
            Coconut,
            Fish,
            Mango,
            Meat,
        }

    }
}
