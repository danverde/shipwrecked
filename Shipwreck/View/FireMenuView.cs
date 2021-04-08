using Shipwreck.Control;
using System;

namespace Shipwreck.View
{
    class FireMenuView : View
    {
        protected override string Message => "\n\n----------------------------------"
                                             + "\n| Fire Menu"
                                             + "\n----------------------------------"
                                             + "\n F - Fire Status"
                                             + "\n A - Add Wood"
                                             + "\n E - Extinguish Fire"
                                             + "\n S - Start Fire"
                                             + "\n X - Close Fire Menu"
                                             + "\n----------------------------------";

        protected override bool HandleInput(string menuItem)
        {
            var closeView = false;
            switch(menuItem)
            {
                case "F":
                    ShowStatus();
                    break;
                case "A":
                    AddWood();
                    break;
                case "E":
                    ExtinguishFire();
                    break;
                case "S":
                    StartFire();
                    break;
            }
            return closeView;
        }

        private void ShowStatus()
        {
            var fire = Shipwreck.CurrentGame.Fire;
            var fireStatus = fire.Status.ToString();
            var wood = fire.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            var woodQuantity = wood?.Quantity ?? 0;

            Console.WriteLine("\n-------------------------\n Fire Status:\n-------------------------");
            Console.WriteLine($" {fireStatus}");
            Console.WriteLine($" Remaining Wood: {woodQuantity}");
            Console.WriteLine("-------------------------");
            Continue();
        }

        private void AddWood()
        {
            var woodRecord = Shipwreck.CurrentGame?.Player.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            var inventoryQuantity = woodRecord?.Quantity ?? 0;
            Console.WriteLine($"You have {inventoryQuantity} Wood. How much would you like to put on the fire?");
            var sQuantity = Console.ReadLine();
            try
            {
                int.TryParse(sQuantity, out var quantityToAdd);
                var numRemoved = FireController.AddWood(quantityToAdd);
                Console.WriteLine($"Successfully added {numRemoved} wood to the fire");
                Continue();
            }
            catch (Exception e)
            {
                // TODO was a custom exception. Will need to be cleaned up
                Console.WriteLine(e.Message);
                Continue();
            }
        }

        private void ExtinguishFire()
        {
            Shipwreck.CurrentGame?.Fire.ExtinguishFire();
            Console.WriteLine("The Fire was extinguished");
            Continue();
        }

        private void StartFire()
        {
            try
            {
                FireController.StartFire();
                Console.WriteLine("The Fire was started");
                Continue();
            } 
            catch(Exception e)
            {
                // TODO was a custom exception. Will need to be cleaned up
                Console.WriteLine("You can't start the fire without a match!");
                Continue();
            }
        }
    }
}
