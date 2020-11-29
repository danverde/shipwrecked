﻿using System.Collections.Generic;
using Shipwreck.Model.Items;

namespace Shipwreck.Model.Character
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int BaseAttack { get; protected set; }
        public int BaseDefense { get; protected set; }
        public CharacterStatus Status { get; set; }
        
        public int Level { get; protected set; }
        public int CalculatedAttack => BaseAttack + (Inventory.ActiveWeapon?.AttackPower ?? 0);

        public int CalculatedDefense => BaseDefense + (Inventory.ActiveArmor?.DefensePower ?? 0);
        public Inventory Inventory { get; set; }

        public Character() {}
        
        public Character(string name = "Barbarian", int health = 20, int maxHealth = 20, int level = 1, int attack = 1, int defense = 0)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            BaseAttack = attack;
            BaseDefense = defense;
            Level = level;
            Status = CharacterStatus.Alive;

            Inventory = new Inventory
            {
                Items = new List<InventoryRecord>()
            };
        }

        public void Die()
        {
            Status = CharacterStatus.Dead;
        }
    }
}