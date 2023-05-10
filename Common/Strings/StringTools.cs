using System.Linq;

namespace Aoc.Common.Strings;

public static class StringTools
{
    public static bool IsLower(string s)
    {
        return s.All(char.IsLower);
    }

    public static bool IsUpper(string s)
    {
        return s.All(char.IsUpper);
    }
}