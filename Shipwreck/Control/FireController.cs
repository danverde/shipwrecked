﻿using Shipwreck.Exceptions;
using Shipwreck.Model;
using Shipwreck.Model.Items;

namespace Shipwreck.Control
{
    class FireController
    {
        public static void Burn(Fire fire)
        {
            if (fire.Status != FireStatus.Burning)
            {
                return;
            }

            // TODO improve null checking
            var wood = fire.Inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
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
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            // TODO fix null checking
            var woodRecord = inventory.Items.Find(x => x.InventoryItem.Name == "Branch");
            // var inventoryQuantity = woodRecord?.Quantity ?? 0;

            var numRemoved = inventory.RemoveItems(woodRecord.InventoryItem, quantityToAdd);
            Shipwreck.CurrentGame?.Fire.AddWood(quantityToAdd);
            return numRemoved;
        }

        public static void StartFire()
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            var match = Shipwreck.ResourceFactory.GetResource(Resource.Type.Match);
            inventory.RemoveItems(match, 1, true);
            Shipwreck.CurrentGame?.Fire.StartFire();
        }
    }
}