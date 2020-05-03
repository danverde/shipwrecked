using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; private set; }
        
        // private Inventory Inventory { get; }
        // private Item ActiveWeapon { get; set; }
        // private Location Location { get; }

        public Character(string name = "enemy", int health = 20, int maxHealth = 20, int attack = 1, int defense = 0)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
            Defense = defense;
        }
    }
}
