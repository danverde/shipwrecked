using System;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Model.Items;

namespace Shipwreck.Helpers
{
    public static class ViewHelpers
    {
        public static void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
        
        public static bool OverwriteFileName(string fileName)
        {
            return fileName == Shipwreck.CurrentGame.SaveFileName ||
                   Prompt.Confirm($"{fileName} already exists. Would you like to overwrite it?", true);
        }
        
        public static int GetQuantity(string message, int maxQuantity)
        {
            return Prompt.Input<int>(message, 0, new[] {CustomValidators.IsLessOrEqualTo(maxQuantity)});
        }

        // public static Item GetInventoryItem(string message)
        // {
        //     var inventory = Shipwreck.CurrentGame.Player.Inventory;
        //     Console.WriteLine(message);
        //     var itemName = Console.ReadLine();
        //
        //     return InventoryController.GetItemFromInventory(inventory, itemName);
        // }
    }
}