using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Factories
{
    class FoodFactory
    {
        public Food GetFood(Food.Type type)
        {
            Food food = null;
            switch(type)
            {
                case Food.Type.Banana:
                    food = new Food("Banana", "My toddler loves these", type, 0, 1);
                    break;
                case Food.Type.Coconut:
                    food = new Food("Coconut", "Fallen Coconut", type, 2, 1);
                    break;
                case Food.Type.Fish:
                    food = new Food("Fish", "Fresh Fish", type, 1, 0);
                    break;
                case Food.Type.Mango:
                    food = new Food("Mango", "Delicious Mango", type, 4, 3);
                    break;
                case Food.Type.Meat:
                    food = new Food("Meat", "Red Meat", type, 2, 3);
                    break;
            }
            return food;
        }
    }
}
