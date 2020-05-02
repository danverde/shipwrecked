using Shipwreck.Model;
using Shipwreck.View;
using System;

namespace Shipwreck
{
    class Shipwreck
    {
        public static Game currentGame;
        static void Main(string[] args)
        {
            LauncherView launcherView = new LauncherView();
            launcherView.Display();
        }
    }
}
