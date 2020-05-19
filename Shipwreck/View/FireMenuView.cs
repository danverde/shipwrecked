using Shipwreck.Control;
using Shipwreck.Exceptions;
using Shipwreck.Model;
using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class FireMenuView : View
    {
        public FireMenuView()
            :base("\n\n----------------------------------"
                  + "\n| Fire Menu"
                  + "\n----------------------------------"
                  + "\n F - Fire Status"
                  + "\n A - Add Wood"
                  + "\n E - Extinguish Fire"
                  + "\n S - Start Fire"
                  + "\n X - Close Inventory"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            bool done = false;
            string menuItem = value.ToUpper();
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
            return done;
        }

        private void ShowStatus()
        {
            Fire fire = Shipwreck.CurrentGame?.Fire;
            string fireStatus = fire.IsBurning == true ? "Burning" : "Extinguished";
            InventoryRecord wood = fire.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            int woodQuantity = wood?.Quantity ?? 0;

            Console.WriteLine("\n-------------------------\n Fire Status:\n-------------------------");
            Console.WriteLine($" {fireStatus}");
            Console.WriteLine($" Remaining Wood: {woodQuantity}");
            Console.WriteLine("-------------------------");
            Continue();
        }

        private void AddWood()
        {
            InventoryRecord woodRecord = Shipwreck.CurrentGame?.Player.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            int inventoryQuantity = woodRecord?.Quantity ?? 0;
            Console.WriteLine($"You have {inventoryQuantity} Wood. How much would you like to put on the fire?");
            string sQuantity = Console.ReadLine();
            try
            {
                int.TryParse(sQuantity, out int quantityToAdd);
                int numRemoved = FireController.AddWood(quantityToAdd);
                Console.WriteLine($"Sucessfully added {numRemoved} wood to the fire");
                Continue();
            }
            catch (InventoryException e)
            {
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
            catch(InventoryException)
            {
                Console.WriteLine("You can't start the fire without a match!");
                Continue();
            }
        }

        private void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
