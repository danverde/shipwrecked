using System;

namespace Shipwreck.View
{
    public class SimpleView
    {
        public string Message { get; set; }
        
        public void Display()
        {
            Console.WriteLine(Message);
            Console.ReadLine();
        }
    }
}