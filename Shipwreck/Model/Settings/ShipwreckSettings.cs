using System;
using System.IO;    

namespace Shipwreck.Model.Settings
{
    public class ShipwreckSettings
    {
        public string PartialSavePath { get; set; }
        public string EasyGameSettingsPath { get; set; }
        public string SavePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), PartialSavePath);
    }
}