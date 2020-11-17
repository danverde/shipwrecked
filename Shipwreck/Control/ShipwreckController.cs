using System;
using Newtonsoft.Json;
using Shipwreck.Helpers;

// using Shipwreck.Helpers;

namespace Shipwreck.Control
{
    public static class ShipwreckController
    {
        public static bool TrySaveGame(string fileName)
        {
            var success = true;
            var gameString = JsonConvert.SerializeObject(Shipwreck.CurrentGame);
            var filePath = $"/Users/verde/Desktop/saves/{fileName}";

            try
            {
                FileWriter.WriteFile(filePath, gameString);
                // File.WriteAllText(filePath, gameString);
            }
            catch (Exception ex)
            {
                success = false;
            }
            
            return success;
        }
    }
}