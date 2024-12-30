using System.Text;

namespace Pzl.Tools.Strings;

public static class ByteConverter
{
    public static string ToString(byte[] bytes) => Encoding.ASCII.GetString(bytes);
    public static string ToHexString(IEnumerable<byte> bytes) => string.Join("", bytes.Select(ToHexString));
    public static string ToHexString(byte b) => b.ToString("X2").ToLower();
}