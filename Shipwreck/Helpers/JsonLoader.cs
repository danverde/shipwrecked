using System;
using System.IO;
using Newtonsoft.Json;

namespace Shipwreck.Helpers
{
    public static class JsonLoader
    {
        public static T LoadJson<T>(string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            
            using var r = new StreamReader(filePath);
            var fileContents = r.ReadToEnd();

            var parsedFileContents = JsonConvert.DeserializeObject<T>(fileContents);
            
            return parsedFileContents;
        }
    }
}