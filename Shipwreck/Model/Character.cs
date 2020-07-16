using Shipwreck.Model.Items;

namespace Shipwreck.Model
{
    class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int BaseAttack { get; protected set; }
        public int BaseDefense { get; protected set; }
        public bool IsAlive { get; private set; }
        
        public int Level { get; protected set; }
        public int CalculatedAttack
        {
            get{ return BaseAttack + (Inventory.ActiveWeapon?.AttackPower ?? 0);  }
        }
        public int CalculatedDefense
        {
            get { return BaseDefense + (Inventory.ActiveArmor?.DefensePower ?? 0); }
        }
        public Inventory Inventory { get; }
        // private Location Location { get; }

        public Character(string name = "Barbarian", int health = 20, int maxHealth = 20, int level = 1, int attack = 1, int defense = 0)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            BaseAttack = attack;
            BaseDefense = defense;
            Level = level;

            Inventory = new Inventory();
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
