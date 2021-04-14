using System;

namespace Shipwreck.Model.Views
{
    public class MenuItem
    {
        public string DisplayName { get; set; }
        public MenuItemType Type { get; set; }
        public Func<bool> IsActive { get; set; } = () => true;
    }

    public enum MenuItemType
    {
        // Main Menu
        NewGame,
        LoadGame,
        Close,
        
        // Help Menu
        HelpMenu,
        PurposeHelp,
        MapHelp,
        
        // Game Menu
        ViewCharacter,
        ViewInventory,
        ViewMap,
        Move,
        Explore,
        Wait,
        SaveGame,
        
        // inventory menu
        ViewFood,
        EatFood,
        DropItem,
    }
}