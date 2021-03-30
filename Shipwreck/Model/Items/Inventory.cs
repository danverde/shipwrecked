using System.Collections.Generic;

namespace Shipwreck.Model.Items
{
    public class Inventory
    {
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }
        public List<InventoryRecord> Items { get; set; }
    }
}
