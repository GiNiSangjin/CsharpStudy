using System;
using System.Collections.Generic;

namespace CsharpStudy
{
    
    internal class Program
    {
        private static readonly List<string> ValidDeviceTypes = new List<string> { "D", "M", "ZR" };
        static void Main(string[] args)
        {
            Console.Write("Device 입력: ");
            string input = (Console.ReadLine() ?? "").Trim();

            DeviceParseInfo info = ParseDevice(input);

            string message = GetDeviceResultMessage(
                info.Result, info.DeviceType, info.Address);

            Console.WriteLine(message);
            

        }

        static int FindFirstDigitIndex(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        static bool IsAllLetters(string text, int endIndex)
        {
            for (int i = 0; i < endIndex; i++)
            {
                if (!char.IsLetter(text[i]))
                    return false;
            }

            return true;
        }

        static bool IsSupportedDeviceType(string deviceType)
        {
            return ValidDeviceTypes.Contains(deviceType);
        }

        static bool TryParseAddress(string addressText, out int address)
        {
            if (int.TryParse(addressText, out int parsedAddress)
                && parsedAddress >= 0)
            {
                address = parsedAddress;
                return true;
            }

            address = 0;
            return false;
        }

        static DeviceParseInfo ParseDevice(string device)
        {
            if(string.IsNullOrWhiteSpace(device))
            {
                return new DeviceParseInfo(DeviceParseResult.EmptyInput, "", 0);
            }
            
            device = device.Trim();

            int firstDigitIndex= FindFirstDigitIndex(device);

            if(firstDigitIndex == -1) 
            {
                return new DeviceParseInfo(DeviceParseResult.InvalidAddress, "", 0);
            }

            if(firstDigitIndex == 0)
            {
                return new DeviceParseInfo(DeviceParseResult.MissingDeviceType, "", 0);
            }

            if(!IsAllLetters(device, firstDigitIndex))
            {
                return new DeviceParseInfo(DeviceParseResult.InvalidDeviceTypeFormat, "", 0);
            }
            string parsedDeviceType = device.Substring(0, firstDigitIndex).ToUpper();

            if (!IsSupportedDeviceType(parsedDeviceType))
            {
                return new DeviceParseInfo(DeviceParseResult.UnsupportedDeviceType, "", 0);
            }

            string addressText = device.Substring(firstDigitIndex);

            if(TryParseAddress(addressText, out int parsedAddress))
            {
                return new DeviceParseInfo(DeviceParseResult.Success, parsedDeviceType, parsedAddress);
            }

            return new DeviceParseInfo(DeviceParseResult.InvalidAddress, "", 0);
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
        
        static DeviceParseResult TryParseDevice(string device, out string deviceType, out int address)
        {
            deviceType = "";
            address = 0;

            if (string.IsNullOrWhiteSpace(device))
            {
                return DeviceParseResult.EmptyInput;
            }

            device = device.Trim();

            int firstDigitIndex = FindFirstDigitIndex(device);

            if (firstDigitIndex == -1)
            {
                return DeviceParseResult.InvalidAddress;
            }

            if (firstDigitIndex == 0)
            {
                return DeviceParseResult.MissingDeviceType;
            }

            if(!IsAllLetters(device, firstDigitIndex))
            {
                return DeviceParseResult.InvalidDeviceTypeFormat;

            }

            string parsedDeviceType = device.Substring(0, firstDigitIndex).ToUpper();

            if(!IsSupportedDeviceType(parsedDeviceType))
            {
                return DeviceParseResult.UnsupportedDeviceType;
            }

            string addressText = device.Substring(firstDigitIndex);

            if (TryParseAddress(addressText, out address)) 
            {
                deviceType = parsedDeviceType;
                return DeviceParseResult.Success;
            }


            return DeviceParseResult.InvalidAddress;
        }

        
    }
}
