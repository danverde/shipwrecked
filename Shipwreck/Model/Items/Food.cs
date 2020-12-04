namespace Shipwreck.Model.Items
{
    public class Food : Item
    {
        protected override ItemType ItemType { get; } = ItemType.Food;
        public override string StringItemType { get; } = ItemType.Food.ToString();
        public FoodType FoodType { get; set; }
        public int HealingPower { get; set; }
        public int FillingPower { get; set; }

        public Food()
        {
            ItemType = ItemType.Food;
        }
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
