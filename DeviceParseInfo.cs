using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy
{
    internal class DeviceParseInfo
    {
        public DeviceParseResult Result { get; }

        public string DeviceType { get; }

        public int Address { get; }

        public DeviceParseInfo(DeviceParseResult result, string deviceType, int address)
        {
            Result = result;
            DeviceType = deviceType;
            Address = address;
        }
    }
}
