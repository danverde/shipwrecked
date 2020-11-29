using System;
using System.IO;
using Newtonsoft.Json;
using Shipwreck.Helpers;
using Shipwreck.Model.Game;
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
                fileName = FileHelper.AddExtension(fileName, ".json");
            
                // check for existing file & ask to override
                var fileExists = FileHelper.FileExists(savePath, fileName);
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

        public static bool TryLoadGame(string fileName)
        {
            try
            {
                var filePath = Path.Combine(Shipwreck.Settings.SavePath, fileName);
                var game = FileHelper.LoadJson<Game>(filePath);
                Shipwreck.CurrentGame = game;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}