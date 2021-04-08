using System;
using System.Collections.Generic;
using System.Linq;

namespace Shipwreck.View
{
    public abstract class Menu
    {
        public string Title { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public void Display()
        {
            Console.WriteLine("\n\n----------------------------------");
            Console.WriteLine($"\n| {Title}");
            Console.WriteLine("\n----------------------------------");
            foreach (var menuItem in MenuItems.Where(menuItem => menuItem.Active))
            {
                Console.WriteLine($"\n {menuItem.DisplayName}");
            }
            Console.WriteLine("\n----------------------------------");
        }
    }

    public abstract class MenuItem
    {
        public string DisplayName { get; set; }
        // public char Character { get; set; }
        public virtual bool Active => true;

        public abstract void DoAction(); // TODO is that too much?
    }
}