using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    public class FoodFactory
    {
        public Food GetFood(FoodType foodType)
        {
            Food food = null;
            switch(foodType)
            {
                case FoodType.Banana:
                    food = new Food
                    {
                        Name = "Banana",
                        Description = "My toddler loves these",
                        FoodType = foodType,
                        HealingPower = 0,
                        FillingPower = 1,
                        Droppable = true
                    };
                    break;
                case FoodType.Coconut:
                    food = new Food{
                        Name = "Coconut",
                        Description = "Fallen Coconut",
                        FoodType = foodType,
                        HealingPower = 2,
                        FillingPower = 1,
                        Droppable = true
                    };
                    break;
                case FoodType.Fish:
                    food = new Food{
                        Name = "Fish",
                        Description = "Fresh Fish",
                        FoodType = foodType,
                        HealingPower = 1,
                        FillingPower = 0,
                        Droppable = true
                    };
                    break;
                case FoodType.Mango:
                    food = new Food{
                        Name = "Mango",
                        Description = "Delicious Mango",
                        FoodType = foodType,
                        HealingPower = 4,
                        FillingPower = 3,
                        Droppable = true
                    };
                    break;
                case FoodType.Meat:
                    food = new Food{
                        Name = "Meat",
                        Description = "Red Meat",
                        FoodType = foodType,
                        HealingPower = 2,
                        FillingPower = 4,
                        Droppable = true
                    };
                    break;
            }
            return food;
        }
    }
}
