using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shipwreck.Helpers;
using Shipwreck.Model.Character;
using Shipwreck.Model.Game;
using Shipwreck.Model.Map;

namespace Shipwreck.Control
{
    public static class MapController
    {
        public static Map LoadMapFromJson(string mapPath)
        {
            var map1Path = Path.Combine(Environment.CurrentDirectory, mapPath);
            return  FileHelper.LoadJson<Map>(map1Path);
        }

        public static Location GetCharacterLocation(Character character)
        {
            return Shipwreck.CurrentGame.Map.Locations[character.Row, character.Col];
        }

        // TODO I can see a try method making sense where you're only doing one thing, but custom exceptions really seem like the right way to go on more complex functions like this
        public static bool TryMove(Map map, Character character, Direction direction, out Location newLocation)
        {
            var adjacentLocation =
                GetAdjacentCoordinates(GetCharacterLocation(character), map)
                    .FirstOrDefault(location => location.Direction == direction) ?? new AdjacentCoordinate();
            
            // get the new location safely
            if (!TryGetLocation(map, adjacentLocation.Row, adjacentLocation.Col, out newLocation)) return false;

            // explore the new location
            newLocation.Explored = true;
            
            // time passes
            GameController.AdvanceDays(newLocation.Scene.DaysToTraverse);
            if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return false;

            // if the explored location isn't traversable, quit
            if (!newLocation.IsTraversable) return false;
            
            // move character
            GetCharacterLocation(character).Characters.Remove(character);
            newLocation.Characters.Add(character);
            CharacterController.SetCharacterLocation(character, newLocation);
            
            // win if applicable
            if (newLocation.Scene.Type == SceneType.Town)
            {
                GameController.WinGame();
            }
            
            return true;
        }

        public static List<Direction> GetValidMovableDirections(Map map, Character character)
        {
            var validDirections = new List<Direction>();
            var adjacentLocations = GetAdjacentCoordinates(GetCharacterLocation(character), map);

            foreach (var adjacentLocation in adjacentLocations)
            {
                // TODO only check is traversable if it's been visited & FOW is enabled
                // if (TryGetLocation(map, adjacentLocation.Row, adjacentLocation.Col, out var location) && location.IsTraversable) validDirections.Add(adjacentLocation.Direction);
                if (!TryGetLocation(map, adjacentLocation.Row, adjacentLocation.Col, out var location))
                {
                    continue;
                }

                if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !location.Explored || location.IsTraversable)
                {
                    validDirections.Add(adjacentLocation.Direction);
                }
            }
            
            return validDirections;
        }

        public static bool TryExploreAdjacentLocations(Map map, Location location)
        {
            try
            {

                if (map == null || location == null) return false;

                var adjacentCoordinates = GetAdjacentCoordinates(location, map);
                foreach (var adjacentCoordinate in adjacentCoordinates)
                {
                    map.Locations[adjacentCoordinate.Row, adjacentCoordinate.Col].Explored = true;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            { // empty on purpose
            }

            return true;
        }
        
        public static List<AdjacentCoordinate> GetAdjacentCoordinates(Location location, Map map)
        {
            if (map == null) return new List<AdjacentCoordinate>();
            var coordinates = new List<AdjacentCoordinate>();

            if (location.Row - 1 > -1)
            {
                coordinates.Add(new AdjacentCoordinate { Direction = Direction.North, Row = location.Row - 1, Col = location.Col});
            }
            
            if (location.Col + 1 < map.NumCols)
            {
                coordinates.Add(new AdjacentCoordinate { Direction = Direction.East, Row = location.Row, Col = location.Col + 1});
            }
            
            if (location.Row + 1 < map.NumRows)
            {
                coordinates.Add(new AdjacentCoordinate { Direction = Direction.South, Row = location.Row + 1, Col = location.Col});
            }
            
            if (location.Col - 1 > -1)
            {
                coordinates.Add(new AdjacentCoordinate { Direction = Direction.West, Row = location.Row, Col = location.Col - 1});
            }

            return coordinates;
        }
        
        private static bool TryGetLocation(Map map, int row, int col, out Location location)
        {
            var validLocation = true;
            location = new Location();
            try
            {
                validLocation = map.Locations[row, col] != null;
                if (validLocation) location = map.Locations[row, col];
            }
            catch (Exception ex)
            {
                validLocation = false;
            }

            return validLocation;
        }
    }
}