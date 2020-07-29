using Shipwreck.Model;
using Shipwreck.Model.Factories;
using Shipwreck.View;
using System;

namespace Shipwreck
{
    class Shipwreck
    {
        public static Game CurrentGame;
        public static ResourceFactory ResourceFactory;

        static void Main(string[] args)
        {
            InitializeFactories();
            
            CurrentGame = new Game();

            Console.WriteLine("======================================================================"
                + "\nCongratulations!! You just washed up on the shore of a tropical "
                + "\nIsland after your cruise ship sunk. Your goal is survive however you"
                + "\ncan! You can either try and escape on your own by building a raft &"
                + "\nfloating to safety. Or maybe building a large signal fire on the beach"
                + "\nwill attract help. Maybe your best bet is to simply wait patiently"
                + "\ntill someone comes to find you. I mean, after such a big ship"
                + "\nwent down SOMEONE's bound to come looking for survivors, Right?"
                + "\n======================================================================");


            new MainMenuView().Display();
            
            Console.WriteLine("DONE");
        }

        private static void InitializeFactories()
        {
            ResourceFactory = new ResourceFactory();
        }
    }
}
