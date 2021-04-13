using System;
using System.Collections.Generic;
using System.Linq;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Model.Game;
using Shipwreck.Model.Items;

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
            while(closeView == false && (!InGameView || Shipwreck.CurrentGame.Status != GameStatus.Over))
            {
                var menuItems = MenuItems.Where(x => x.IsActive()).Select(x => x.DisplayName).ToList();
                var input = Prompt.Select($"| {Title}", menuItems);
                var selectedMenuItem = MenuItems.Find(x => x.DisplayName == input);
                closeView = HandleInput(selectedMenuItem);
            }
        }
        
        protected abstract bool HandleInput(MenuItem menuItem);

        /* Helpers */
        
        protected void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
