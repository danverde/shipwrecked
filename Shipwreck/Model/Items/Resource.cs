namespace Shipwreck.Model.Items
{
    public class Resource : Item
    {
        protected override ItemType ItemType { get; } = ItemType.Resource;
        public override string StringItemType { get; } = ItemType.Resource.ToString();
        public ResourceType ResourceType { get; set; }

        public Resource()
        {
            ItemType = ItemType.Resource;
        }
    }
    
    public enum ResourceType
    {
        Branch,
        Match,
        SharpStone,
        Stone,
        Vine,
    }
}
