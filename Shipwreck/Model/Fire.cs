using Shipwreck.Model.Factories;
using Shipwreck.Model.Items;

namespace Shipwreck.Model
{
    class Fire
    {
        public FireStatus Status { get; private set; }
        public Inventory Inventory { get; }

        public Fire()
        {
            Status = FireStatus.NotStarted;
            Inventory = new Inventory();
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
            if (quantity == 0)
            {
                return;
            }
            var resourceFactory = new ResourceFactory();
            var wood = resourceFactory.GetResource(Resource.Type.Branch);
            Inventory.AddItem(wood, quantity);
        }
    }
}
