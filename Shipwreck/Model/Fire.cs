using System.Collections.Generic;
using Shipwreck.Control;
using Shipwreck.Model.Items;

namespace Shipwreck.Model
{
    public class Fire
    {
        public FireStatus Status { get; private set; }
        public Inventory Inventory { get; }

        public Fire()
        {
            Status = FireStatus.NotStarted;
            Inventory = new Inventory
            {
                Items = new List<InventoryRecord>()
            };
        }

        public void StartFire()
        {
            Status = FireStatus.Burning;
        }

        public void ExtinguishFire()
        {
            Status = FireStatus.Extinguished;
        }

        public void AddWood(int quantity)
        {
            if (quantity == 0) return;
            var wood = Shipwreck.ResourceFactory.GetResource(ResourceType.Branch);
            InventoryController.AddItem(Inventory, wood, quantity);
        }
    }
}
