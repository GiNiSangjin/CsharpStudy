using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy
{
    internal enum DeviceParseResult
    {
        Success,
        EmptyInput,
        MissingDeviceType,
        InvalidDeviceTypeFormat,
        UnsupportedDeviceType,
        InvalidAddress
    }
}
