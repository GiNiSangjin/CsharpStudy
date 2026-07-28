using System;

namespace CsharpStudy
{
    internal enum WriteValueParseResult
    { 
        Success,
        NotNumber,
        OutOfRange
    }
    internal static class WriteValueParser
    {
        public static WriteValueParseResult TryParseWriteValue(string input, out int value)
        {
            value = 0;
            if(!int.TryParse(input, out int parsedValue))
            {
                return WriteValueParseResult.NotNumber;
            }
            if(parsedValue < 0 || parsedValue > 32767)
            {
                return WriteValueParseResult.OutOfRange;
            }
            value = parsedValue;
            return WriteValueParseResult.Success;
        }

    }
}
