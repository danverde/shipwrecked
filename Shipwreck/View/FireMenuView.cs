using Shipwreck.Control;
using Shipwreck.Exceptions;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private void StartFire()
        {
            throw new NotImplementedException();
        }

        private void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
