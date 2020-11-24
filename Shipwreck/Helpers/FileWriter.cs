using System.IO;
using System.Linq;
using Shipwreck.View;

namespace Shipwreck.Helpers
{
    public static class FileWriter
    {
        public static string AddExtension(string extension, string fileName)
        {
            var existingExtension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(existingExtension)) fileName += extension;
            else if (existingExtension != extension) fileName = fileName.Replace(extension, extension);
            return fileName;
        }

        public static bool FileExists(string directory, string fileName)
        {
            var existingFileNames = Directory.GetFiles(directory).Select(Path.GetFileName).ToList();
            return existingFileNames.Contains(fileName);
        }
    }
}