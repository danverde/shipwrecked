using System;
using Shipwreck.Control;
using Shipwreck.Model.Game;

namespace Shipwreck.View
{
    public class MoveView: Model.Views.View
    {
        protected override string Message
        {
            get
            {
                var validDirections = MapController.GetValidMovableDirections();
                return $"Which direction would you like to travel? ({string.Join(", ", validDirections.ToArray())})";
            }
        }

        protected override bool HandleInput(string input)
        {
            var validDirections = MapController.GetValidMovableDirections();

            if (!validDirections.Contains(input))
            {
                Console.WriteLine("That is not a valid direction");
                return false;
            }

            switch (input)
            {
                case "N":
                    Move("N", "north");
                    Continue();
                    break;
                case "E":
                    Move("E", "east");
                    Continue();
                    break;
                case "S":
                    Move("S", "south");
                    Continue();
                    break;
                case "W":
                    Move("W", "west");
                    Continue();
                    break;
            }
            
            return true;
        }

        private void Move(string direction, string fullDirection)
        {
            var newCoordinate = MapController.GetAdjacentCoordinates(MapController.GetPlayerLocation())
                .Find(coordinate => coordinate.Direction == direction);
            if (newCoordinate == null) return;
            
            var newLocationVisited = Shipwreck.CurrentGame.Map.Locations[newCoordinate.Row, newCoordinate.Col].Visited;
            
            var success = MapController.TryMove(direction, out var location);
            
            // check if the game ended (found town or ran out of hunger) 
            if (Shipwreck.CurrentGame.Status != GameStatus.Playing)
            {
                return;
            }
            
            GameMenuView.ShowMap();
            
            if (success)
            {
                var successMsg = $"You successfully moved moved {fullDirection}";
                // TODO I need a try explore method. just b/c FOW is on doesn't mean I just discovered it.
                // It would also be good to give more details about the new location
                if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !newLocationVisited) successMsg += $" and discovered {location.Scene.Description}";
                
                Console.WriteLine(successMsg);
            }
            else
            {
                Console.WriteLine($"You were unable to move {fullDirection}");
            }
        }
    }
}