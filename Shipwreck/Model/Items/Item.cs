using JsonSubTypes;
using Newtonsoft.Json;

namespace Shipwreck.Model.Items
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]

    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Droppable { get; set; }
        public virtual ItemType ItemType { get; }
    }
}
