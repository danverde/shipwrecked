using Shipwreck.Model.Character;
using Shipwreck.Model.Items;

namespace Shipwreck.Control
{
    public static class PlayerController
    {
        public static int Eat(Food food, int quantity)
        {
            // update player
            var player = Shipwreck.CurrentGame.Player;
            player.Health += food.HealingPower * quantity;
            player.Hunger += food.FillingPower * quantity;

            if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
            if (player.Hunger > Player.HungerLimit) player.Hunger = Player.HungerLimit;

            // remove item from inventory
            return InventoryController.RemoveItems(player.Inventory, food, quantity);
        }
    }
}