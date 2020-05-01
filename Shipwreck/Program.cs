using Shipwreck.Model;
using Shipwreck.View;
using System;

namespace Shipwreck
{
    class Program
    {
        private Game currentGame = null;
        static void Main(string[] args)
        {
            LauncherView launcherView = new LauncherView();
            launcherView.Display();
        }
    }
}
