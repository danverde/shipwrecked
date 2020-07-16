namespace Shipwreck.Model.Items
{
    abstract class Weapon : IGear
    {
        public string Name { get; }
        public string Description { get; }
        public bool Droppable { get; }
        public abstract int AttackPower { get; }

        // b/c each weapon has a separate class, I have to have a separate factory
        // if I store required materials on a JSON obj, maybe I can combine the constructor & factory
        public Weapon(string name, string description, bool droppable = true)
        {
            Name = name;
            Description = description;
            Droppable = droppable;
        }
    }
}
