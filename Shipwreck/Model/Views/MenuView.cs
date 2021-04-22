using System.Collections.Generic;
using System.Linq;
using Sharprompt;

namespace Shipwreck.Model.Views
{
    public abstract class MenuView
    {
        protected virtual string Title => "";
        protected virtual List<MenuItem> MenuItems => new List<MenuItem>();
        public virtual bool InGameView { get; set; }

        public void Display()
        {
            var closeView = false;
            while(closeView == false && (!InGameView || Shipwreck.CurrentGame.Status != Game.Game.GameStatus.Over))
            {
                closeView = true;
                var menuItems = MenuItems.Where(x => x.IsActive()).Select(x => x.DisplayName).ToList();
                var input = Prompt.Select($"| {Title}", menuItems);
                var selectedMenuItem = MenuItems.Find(x => x.DisplayName == input);
                if (selectedMenuItem == null || !selectedMenuItem.IsActive()) {continue;}
                if (selectedMenuItem.Type != MenuItemType.Close)
                {
                    closeView = HandleInput(selectedMenuItem);
                }
            }
        }
        
        protected abstract bool HandleInput(MenuItem menuItem);
    }
}
