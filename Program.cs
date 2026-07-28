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

            string message = GetDeviceResultMessage(
                info.Result, info.DeviceType, info.Address);

            Console.WriteLine(message);
            

        }

        static string GetDeviceResultMessage(DeviceParseResult result, string deviceType, int address)
        {
            switch (result)
            {
                case DeviceParseResult.Success:
                    return $"출력 성공 Device Type: {deviceType}, Address: {address}";

                case DeviceParseResult.EmptyInput:
                    return "Device를 입력하세요.";
                    

                case DeviceParseResult.UnsupportedDeviceType:
                    return "지원하지 않는 Device 종류입니다.";
                    

                case DeviceParseResult.MissingDeviceType:
                    return "Missing Device Type입니다.";

                case DeviceParseResult.InvalidDeviceTypeFormat:
                    return "유효하지 않은 Device 형태입니다.";

                case DeviceParseResult.InvalidAddress:
                    return "유효하지 않은 주소입니다.";
                

                default:
                return "Device 형식이 올바르지 않습니다.";
                    
            }
        }
        
    }
}
