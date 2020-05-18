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
            catch (InventoryException e)
            {
                fire.ExtinguishFire();
            }
        }
    }
}
