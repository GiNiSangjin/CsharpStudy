using System;
using System.Collections.Generic;

namespace CsharpStudy
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Device 입력: ");
            string input = (Console.ReadLine() ?? "").Trim();

            DeviceParseInfo info = DeviceParser.ParseDevice(input);

            string message = DeviceMessageProvider.GetMessage(info);

            Console.WriteLine(message);
            
        }
    }
}
