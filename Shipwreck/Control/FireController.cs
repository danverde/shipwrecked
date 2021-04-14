using System;
using System.Linq;
using Shipwreck.Model;
using Shipwreck.Model.Items;

namespace Shipwreck.Control
{
    public static class FireController
    {
        public static void Burn(Fire fire)
        {
            if (fire.Status != FireStatus.Burning)
            {
                return;
            }

            var wood = fire.Inventory.Items.FirstOrDefault(record => record.InventoryItem.Name == "Branch");
            if (wood == null) return;
            
            // TODO address edge cases where a partial number of wood was removed...
            try
            {
                InventoryController.RemoveItems(fire.Inventory, wood.InventoryItem,
                    Shipwreck.CurrentGame.GameSettings.Fire.WoodBurnPerDay);
            }
            catch (Exception e)
            {
                // TODO was a custom exception. put out the fire another way
                fire.ExtinguishFire();
            }
        }

        public static int AddWood(int quantityToAdd)
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            var woodRecord = inventory.Items.FirstOrDefault(itemRecord => itemRecord.InventoryItem.Name == "Branch");
            if (woodRecord == null) return 0;

            var numRemoved = InventoryController.RemoveItems(inventory, woodRecord.InventoryItem, quantityToAdd);
            Shipwreck.CurrentGame?.Fire.AddWood(quantityToAdd);
            return numRemoved;
        }

        public static void StartFire()
        {
            // TODO why am I generating a match in order to remove one?
            var match = Shipwreck.ResourceFactory.GetResource(ResourceType.Match);
            if (InventoryController.RemoveItems(Shipwreck.CurrentGame.Player.Inventory, match) >= 1)
            {
                Shipwreck.CurrentGame?.Fire.StartFire();
            }
        }
    }
}
