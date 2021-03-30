using System;
using Shipwreck.Control;
using Shipwreck.Model.Items;

namespace Shipwreck.Helpers
{
    public static class ViewHelpers
    {
        
        public static int GetQuantity(string message)
        {
            var valid = false;
            var quantity = 0;
            do
            {
                Console.WriteLine(message);
                var stringQuantity = Console.ReadLine();
                if (stringQuantity?.ToLower() == "x") continue;
                if (!int.TryParse(stringQuantity, out quantity)) continue;
                valid = true;

            } while (!valid);

            return quantity;
        }
        public static int GetQuantity(string message, int maxQuantity)
        {
            var quantity = GetQuantity(message);
            return quantity > maxQuantity ? maxQuantity : quantity;
        }

        public static Item GetInventoryItem(string message)
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            Console.WriteLine(message);
            var itemName = Console.ReadLine();

            return InventoryController.GetItemFromInventory(inventory, itemName);
        }
    }
}