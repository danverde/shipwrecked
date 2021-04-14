using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Shipwreck.Helpers
{
    public static class FileHelper
    {
        public static string GetSaveFileDirectory()
        {
            var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var baseSavePath = Shipwreck.Settings.SavePath;
            return Path.Combine(userDir, baseSavePath);
        }

        public static List<string> GetFilesInDir(string directory)
        {
            return Directory.GetFiles(directory).Select(Path.GetFileName).ToList();
        }
        
        public static string AddExtension(string fileName, string extension)
        {
            var existingExtension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(existingExtension)) fileName += extension;
            else if (existingExtension != extension) fileName = fileName.Replace(extension, extension);
            return fileName;
        }

        public static bool FileExists(string directory, string fileName)
        {
            var existingFileNames = GetFilesInDir(directory);
            return existingFileNames.Contains(fileName);
        }
        
        public static T LoadJson<T>(string filePath)
        {
            using var r = new StreamReader(filePath);
            var fileContents = r.ReadToEnd();

            var parsedFileContents = JsonConvert.DeserializeObject<T>(fileContents);
            
            return parsedFileContents;
        }
    }
}