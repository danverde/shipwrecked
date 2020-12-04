namespace Shipwreck.Model.Items
{
    public class Food : Item
    {
        public override ItemType ItemType { get; } = ItemType.Food;
        public override string StringItemType { get; } = "Food";
        public FoodType FoodType { get; set; }
        public int HealingPower { get; set; }
        public int FillingPower { get; set; }
    }

    public enum FoodType
    {
        Banana,
        Coconut,
        Fish,
        Mango,
        Meat
    }
}
