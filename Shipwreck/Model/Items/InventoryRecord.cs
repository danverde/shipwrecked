namespace Shipwreck.Model.Items
{
    public class InventoryRecord
    {
        public Item InventoryItem { get; set; }
        public int Quantity { get; set; }

        public InventoryRecord() {}

        public InventoryRecord(Item item, int quantity)
        {
            InventoryItem = item;
            Quantity = quantity;
        }

        public void AddToQuantity(int amountToAdd)
        {
            Quantity += amountToAdd;
        }
    }
}
