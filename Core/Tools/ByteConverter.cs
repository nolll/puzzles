using System.Collections.Generic;
using System.Text;

namespace Core.Tools
{
    public static class ByteConverter
    {
        public static string ConvertToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        
        public static string ConvertToHexString(IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(ConvertToHexString(b));
            }
            
            return sb.ToString();
        }

        public static string ConvertToHexString(byte b)
        {
            return b.ToString("X2").ToLower();
        }
    }
}