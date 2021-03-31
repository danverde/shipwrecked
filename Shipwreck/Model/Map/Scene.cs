using System.Collections.Generic;
using Shipwreck.Model.Items;

namespace Shipwreck.Model.Map
{
    public class Scene
    {
        public string Description { get; set; }
        public string DisplaySymbol { get; set; }
        public bool Traversable { get; set; }
        public int DaysToTraverse { get; set; }
        public SceneType Type { get; set; }
        public List<InventoryRecord> Items { get; set; }
        
        // add an interact method to handle things like dying, visiting a village, etc. Then we couldn't store it as json...
        // unless we used a factory w/ explicit classes? somehow?
    }

    public enum SceneType
    {
        Camp = 0,
        Forest = 1,
        Mountain = 2,
        IceCappedMountain = 3,
        Town = 4,
        Beach = 5
    }
}