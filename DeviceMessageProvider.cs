using System;

namespace CsharpStudy
{
    static internal class DeviceMessageProvider
    {
        internal static string GetMessage(DeviceParseInfo info)
        {
            if (info == null)
            {
                return "There is no parsing result";
            }
            switch (info.Result)
            {
                case DeviceParseResult.Success:
                    return $"출력 성공 Device Type: {info.DeviceType}, Address: {info.Address}";

                case DeviceParseResult.EmptyInput:
                    return "Device를 입력하세요.";

                case DeviceParseResult.UnsupportedDeviceType:
                    return "지원하지 않는 Device 종류입니다.";

                case DeviceParseResult.MissingDeviceType:
                    return "Missing Device Type 입니다.";

                case DeviceParseResult.InvalidDeviceTypeFormat:
                    return "유효하지 않은 Device 형태입니다.";

                case DeviceParseResult.InvalidAddress:
                    return "유효하지 않은 주소입니다.";

                default:
                    return "Device형식이 올바르지 않습니다.";
            }
        }
    }
}
