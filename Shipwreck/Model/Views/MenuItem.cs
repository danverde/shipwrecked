using System;

namespace Shipwreck.Model.Views
{
    public class MenuItem
    {
        public string DisplayName { get; set; }
        public char Character { get; set; }
        public Func<bool> IsActive { get; set; } = () => true;
    }
}