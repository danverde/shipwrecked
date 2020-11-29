﻿using Shipwreck.Model.Items;
using Shipwreck.Model.Map;
using Shipwreck.View;

namespace Shipwreck.Model.Character
{
    class Player : Character
    {
        public int Exp { get; private set; }
        public int Hunger { get; set; }
        public const int HungerLimit = 20; 
        public int Col { get; set; }
        public int Row { get; set; }

        public Player() {}
        
        public Player(string name, int hunger, Location location)
            :base(name)
        {
            Hunger = hunger;
            Row = location.Row;
            Col = location.Col;
        }

        public void SetLocationCoordinates(Location location)
        {
            Row = location.Row;
            Col = location.Col;
        }
        
        public void GainExperience(int experience)
        {
            Exp += experience;
            while (Exp >= 100)
            {
                LevelUp();
                Exp -= 100;
            }
        }

        // TODO should this be in a controller?
        public void Eat(Food food)
        {
            Health = Health + food.HealingPower < MaxHealth ? Health + food.HealingPower : MaxHealth;
            Hunger = Hunger - food.FillingPower > 0 ? Hunger - food.FillingPower : 0;
        }
        
        private void LevelUp()
        {
            var playerSettings = Shipwreck.CurrentGame.GameSettings.Player;
            
            Level++;
            // I'll have to change stat growths later...
            BaseAttack += playerSettings.AttachGrowth;
            BaseDefense += playerSettings.DefenseGrowth;
            MaxHealth += playerSettings.HealthGrowth;
            Health += playerSettings.HealthGrowth;
            
            new LevelUpView().Display();
        }
    }
}