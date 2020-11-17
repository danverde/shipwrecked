using System.IO;

namespace Shipwreck.Helpers
{
    public static class FileWriter
    {
        public static void WriteFile(string filePath, string fileContents)
        {
            File.WriteAllText(filePath, fileContents);
        }
    }
}