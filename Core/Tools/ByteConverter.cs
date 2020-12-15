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
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}