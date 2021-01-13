using System.Collections.Generic;
using System.Text;

namespace Core.Tools
{
    public static class ByteConverter
    {
        public static string ConvertToString(IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(ConvertToString(b));
            }
            
            return sb.ToString();
        }

        public static string ConvertToString(byte b)
        {
            return b.ToString("X2").ToLower();
        }
    }
}