using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class LauncherView : View
    {
        public LauncherView()
        {
            DisplayBanner();
            MainMenuView mainMenuView = new MainMenuView();
            mainMenuView.Display();
        }

        private void DisplayBanner()
        {
            string banner = "======================================================================"
                + "\nCongratulations!! You just washed up on the shore of a tropical "
                + "\nIsland after your cruise ship sunk. Your goal is survive however you"
                + "\ncan! You can either try and escape on your own by buildng a raft &"
                + "\nfloating to safety. Or maybe building a large signal fire on the beach"
                + "\nwill attract help. Maybe your best bet is to simply wait patiently"
                + "\ntill someone comes to find you. I mean, after such a big ship"
                + "\nwent down SOMEONE's bound to come looking for survivors, Right?"
                + "\n======================================================================";
            
            Console.WriteLine(banner);
        }

        // only needed to satisfy the interface...
        public override bool DoAction(string value)
        {
            return false;
        }
    }
}
