using System.Text;

namespace Puzzles.common.Strings;

public static class ByteConverter
{
    public static string ToString(byte[] bytes) => Encoding.ASCII.GetString(bytes);
    public static string ToHexString(IEnumerable<byte> bytes) => string.Concat(bytes.Select(ToHexString));
    public static string ToHexString(byte b) => b.ToString("X2").ToLower();
}