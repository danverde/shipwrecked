using System.Runtime.InteropServices;

namespace Shipwreck.Model.Settings
{
    public class ShipwreckSettings
    {
        public string MacSavePath { get; set; }
        public string WindowsSavePath { get; set; }
        public string SavePath => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? MacSavePath : WindowsSavePath;
    }
}