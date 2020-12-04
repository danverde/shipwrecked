namespace Shipwreck.Model.Items
{
    public class Resource : Item
    {
        public override ItemType ItemType { get; } = ItemType.Resource;
        public ResourceType ResourceType { get; set; }
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
