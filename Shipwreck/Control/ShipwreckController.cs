using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Shipwreck.Helpers;
using Shipwreck.View;

namespace Shipwreck.Control
{
    public static class ShipwreckController
    {
        public static bool TrySaveGame(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) return false;
                
                var savePath = Shipwreck.Settings.SavePath;
            
                // validate name & extension
                fileName = FileWriter.AddExtension(".json", fileName);
            
                // check for existing file & ask to override
                var fileExists = FileWriter.FileExists(savePath, fileName);
                if (fileExists)
                {
                    var overwrite = GameMenuView.OverwriteFileName(fileName);
                    if (!overwrite) return false;
                }

                // write the file
                var gameString = JsonConvert.SerializeObject(Shipwreck.CurrentGame);
                var filePath =  Path.Combine(savePath, fileName);
                File.WriteAllText(filePath, gameString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}