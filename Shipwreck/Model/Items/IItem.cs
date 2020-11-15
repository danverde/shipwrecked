namespace Shipwreck.Model.Items
{
    public interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        public bool Droppable { get; }
    }
}
