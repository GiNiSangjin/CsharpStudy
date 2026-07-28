using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy
{
    internal class DeviceParser
    {
        private static readonly List<string> ValidDeviceTypes = new List<string> { "D", "M", "ZR" };

        internal static DeviceParseInfo ParseDevice(string device)
        {
            if (string.IsNullOrWhiteSpace(device))
            {
                return new DeviceParseInfo(DeviceParseResult.EmptyInput, "", 0);
            }

            device = device.Trim();

            int firstDigitIndex = FindFirstDigitIndex(device);

            if (firstDigitIndex == -1)
            {
                return new DeviceParseInfo(DeviceParseResult.InvalidAddress, "", 0);
            }

            if (firstDigitIndex == 0)
            {
                return new DeviceParseInfo(DeviceParseResult.MissingDeviceType, "", 0);
            }

            if (!IsAllLetters(device, firstDigitIndex))
            {
                return new DeviceParseInfo(DeviceParseResult.InvalidDeviceTypeFormat, "", 0);
            }
            string parsedDeviceType = device.Substring(0, firstDigitIndex).ToUpper();

            if (!IsSupportedDeviceType(parsedDeviceType))
            {
                return new DeviceParseInfo(DeviceParseResult.UnsupportedDeviceType, "", 0);
            }

            string addressText = device.Substring(firstDigitIndex);

            if (TryParseAddress(addressText, out int parsedAddress))
            {
                return new DeviceParseInfo(DeviceParseResult.Success, parsedDeviceType, parsedAddress);
            }

            return new DeviceParseInfo(DeviceParseResult.InvalidAddress, "", 0);
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
    }
}
