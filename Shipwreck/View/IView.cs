using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    interface IView
    {
        public void Display();
        public string GetInput();
        public bool DoAction(string value);
    }
}
