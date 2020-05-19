using Shipwreck.Exceptions;
using Shipwreck.Model;
using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Control
{
    class FireController
    {
        public static void Burn(Fire fire)
        {
            if (fire.IsBurning == false)
            {
                return;
            }

            InventoryRecord wood = fire.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            try
            {
                fire.Inventory.RemoveItems(wood.InventoryItem, Fire.BurnRate, true);
            }
            catch (InventoryException)
            {
                fire.ExtinguishFire();
            }
        }

        public static int AddWood(int quantityToAdd)
        {
            Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            InventoryRecord woodRecord = inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            int inventoryQuantity = woodRecord?.Quantity ?? 0;

            try
            {
                int numRemoved = inventory.RemoveItems(woodRecord.InventoryItem, quantityToAdd);
                Shipwreck.CurrentGame?.Fire.AddWood(quantityToAdd);
                return numRemoved;
            }
            catch(InventoryException e)
            {
                throw e;
            }
        }
    }
}
