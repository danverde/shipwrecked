using System;

namespace Shipwreck.Helpers
{
    public static class Log
    {
        public static void Success(string message)
        {
            Write(message, ConsoleColor.Green);
        }
        
        public static void Info(string message)
        {
            Write(message, ConsoleColor.Cyan);
        }
        
        public static void Warning(string message)
        {
            Write(message, ConsoleColor.Yellow);
        }
        
        public static void Error(string message)
        {
            Write(message, ConsoleColor.Red);
        }
        

        private static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}