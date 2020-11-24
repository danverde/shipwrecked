using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Shipwreck.View;

namespace Shipwreck.Control
{
    public static class ShipwreckController
    {
        public static bool TrySaveGame(string fileName)
        {
            var success = true;
            var savePath = Shipwreck.Settings.SavePath;
            
            
            // TODO validate name & extension
            if (!fileName.Contains(".json")) fileName += ".json";
            
            
            // check for existing file & ask to override
            try
            {
                var existingFileNames = Directory.GetFiles(savePath).Select(Path.GetFileName).ToList();
                if (existingFileNames.Contains(fileName))
                {
                    var overwrite = GameMenuView.OverwriteFileName("fileName");
                    if (!overwrite) return false;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Unable to open directory {savePath}");
                return false;
            }

            
            var gameString = JsonConvert.SerializeObject(Shipwreck.CurrentGame);
            var filePath =  Path.Combine(savePath, fileName);

            try
            {
                File.WriteAllText(filePath, gameString);
            }
            catch (Exception ex)
            {
                success = false;
            }
            
            return success;
        }
    }
}