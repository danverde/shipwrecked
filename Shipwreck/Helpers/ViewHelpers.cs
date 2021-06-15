using System;
using Sharprompt;

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
        
        public static int GetQuantity(string message, int maxQuantity)
        {
            return Prompt.Input<int>(message, 0, new[] {CustomValidators.IsLessOrEqualTo(maxQuantity)});
        }

        public static void ShowNewDay()
        {
            Console.WriteLine("\n---------------------" +
                              $"\n Day {Shipwreck.CurrentGame.Day}" +
                              // $"\n Weather: {Shipwreck.CurrentGame.Day.Weather.Name}" +
                              $"\n Hunger: {Shipwreck.CurrentGame.Player.Hunger} / {Shipwreck.CurrentGame.Player.HungerLimit}" +
                              "\n---------------------");
            Console.ReadKey();
        }

        public static void ShowLevelUp()
        {
            Console.WriteLine("\n\n----------------------------------"
                              + "\n| Level Up"
                              + "\n----------------------------------"
                              + $"\n Level {Shipwreck.CurrentGame.Player.Level}"
                              + $"\n Max Health {Shipwreck.CurrentGame.Player.Health}"
                              // + $"\n Base Attack {Shipwreck.CurrentGame.Player.BaseAttack}"
                              // + $"\n Base Defense {Shipwreck.CurrentGame.Player.BaseDefense}"
                              + "\n----------------------------------");
            Console.ReadKey(); 
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