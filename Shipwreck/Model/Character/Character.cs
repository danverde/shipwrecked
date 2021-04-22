using Shipwreck.Model.Items;

namespace Shipwreck.Model.Character
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public CharacterStatus Status { get; set; }
        public Inventory Inventory { get; set; } // set required to load game
        public int Col { get; set; }
        public int Row { get; set; }

        public int CalculatedAttack => BaseAttack + (Inventory.ActiveWeapon?.AttackPower ?? 0);
        public int CalculatedDefense => BaseDefense + (Inventory.ActiveArmor?.DefensePower ?? 0);
    }
    
    public enum CharacterStatus
    {
        Dead = 0,
        Alive = 1
    }
}
