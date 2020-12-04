using JsonSubTypes;
using Newtonsoft.Json;

namespace Shipwreck.Model.Items
{
    [JsonConverter(typeof(JsonSubtypes), "StringItemType")]
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Droppable { get; set; }
        protected virtual ItemType ItemType { get; }
        public virtual string StringItemType { get; }
    }
    
    public enum ItemType
    {
        Resource,
        Weapon,
        Armor,
        Food
    }
}
