using System.Runtime.InteropServices;

namespace Shipwreck.Model.Settings
{
    public class ShipwreckSettings
    {
        // TODO will protected props get set by incoming JSON?
        public string MacSavePath { get; set; }
        public string WindowsSavePath { get; set; }
        public string SavePath => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? MacSavePath : WindowsSavePath;
    }
}