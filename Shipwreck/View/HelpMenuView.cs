using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class HelpMenuView : View
    {
        public HelpMenuView()
            :base("\n"
                + "\n----------------------------------"
                + "\n| Help Menu"
                + "\n----------------------------------"
                + "\n P - Purpose of the Game"
                + "\n I - Inventory Help"
                + "\n M - Map Terminolagy"
                + "\n R - Resource Help"
                + "\n C - Combat Help"
                + "\n B - Building Help"
                + "\n X - Exit Help Menu"
                + "\n----------------------------------")
        { }
        public override bool DoAction(string value)
        {
            string menuOption = value.ToUpper();
            switch (menuOption) {
                case "P":
                    PurposeHelp();
                    break;
                case "I":
                    ShowInventoryHelp();
                    break;
                case "M":
                    MapHelp();
                    break;
                case "R":
                    ResourceHelp();
                    break;
                case "C":
                    CombatHelp();
                    break;
                case "B":
                    BuildingHelp();
                    break;
            }

            return false;
        }

        private void PurposeHelp()
        {
            Console.WriteLine("\n***************************************************************************"
                + "\n The purpose of the game is to survive however you can. You're stuck on a"
                + "\n tropical Island, so you can either try and escape on your own by buildng"
                + "\n a raft & floating to safety, or by building a large signal fire on"
                + "\n the beach in an attempt to attract help. Maybe your best bet is to simply "
                + "\n wait patiently till someone comes to find you. I mean, after such a big"
                + "\n ship went down SOMEONE's bound to come looking for survivors, Right?"
                + "\n***************************************************************************");
        }

        private void ShowInventoryHelp()
        {
            InventoryHelpView inventoryHelpView = new InventoryHelpView();
            inventoryHelpView.Display();
        }

        private void MapHelp()  
        {
            Console.WriteLine("\n************************************************************************"
                + "\n While in the game you can move your character by entering 'L'."
                + "\n You will then be prompted to enter a direction (N,E,S,W)."
                + "\n Time will elapse while you travel, increasing your hunger."
                + "\n Be aware that some types of terrain are easier to traverse than others"
                + "\n************************************************************************");
        }

        private void ResourceHelp()
        {
            throw new NotImplementedException();
        }

        private void CombatHelp()
        {
            throw new NotImplementedException();
        }

        private void BuildingHelp()
        {
            throw new NotImplementedException();
        }
    }
}
