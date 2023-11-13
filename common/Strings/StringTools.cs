namespace Puzzles.common.Strings;

public static class StringTools
{
    public static bool IsLower(string s) => s.All(char.IsLower);
    public static bool IsUpper(string s) => s.All(char.IsUpper);
}