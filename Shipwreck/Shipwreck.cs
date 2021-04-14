using Shipwreck.Model.Factories;
using Shipwreck.View;
using System;
using System.IO;
using Shipwreck.Helpers;
using Shipwreck.Model.Game;
using Shipwreck.Model.Settings;

namespace Shipwreck
{
    class Shipwreck
    {
        public static Game CurrentGame;

        // TODO should these really be singletons?
        public static FoodFactory FoodFactory;
        public static ResourceFactory ResourceFactory;
        // public static WeaponFactory WeaponFactory;
        // public static ArmorFactory ArmorFactory;
        
        public static ShipwreckSettings Settings;

        private static string SettingsFilePath =>
            Path.Combine(Environment.CurrentDirectory, "Data/Settings/shipwreckSettings.json");

        static void Main(string[] args)
        {
            try
            {
                LoadSettings();
                InitializeFactories();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to start game. Please don't break me.");
            }
            
            Console.WriteLine(StartMessage);

            new MainMenuView().Display();
        }

        private static void LoadSettings()
        {
            Settings = FileHelper.LoadJson<ShipwreckSettings>(SettingsFilePath);
        }

        private static void InitializeFactories()
        {
            FoodFactory = new FoodFactory();
            ResourceFactory = new ResourceFactory();
            // WeaponFactory = new WeaponFactory();
            // ArmorFactory = new ArmorFactory();
        }

        private static string StartMessage =>
                "======================================================================="
                + "\n Congratulations!! You just washed up on the shore of a tropical "
                + "\n Island after your cruise ship sunk. Your goal is survive however you"
                + "\n can! You can either try and escape on your own by building a raft &"
                + "\n floating to safety. Or maybe building a large signal fire on the beach"
                + "\n will attract help. Maybe your best bet is to simply wait patiently"
                + "\n till someone comes to find you. I mean, after such a big ship"
                + "\n went down SOMEONE's bound to come looking for survivors, Right?"
                + "\n=======================================================================\n";
    }
}