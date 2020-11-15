using System.Collections.Generic;
using Shipwreck.Model.Items;

namespace Shipwreck.Model.Map
{
    public class Scene
    {
        public string Description { get; set; }
        public string DisplaySymbol { get; set; }
        public bool Traversable { get; set; }
        public List<InventoryRecord> Items { get; set; }
    }
}