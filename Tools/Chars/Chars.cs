namespace Pzl.Tools.Chars;

public static class Chars
{
    public static bool IsNumeric(char c) => IsBetween(c, '0', '9');
    public static bool IsAlphabeticLower(char c) => IsBetween(c, 'a', 'z');
    public static bool IsAlphabeticUpper(char c) => IsBetween(c, 'A', 'Z');
    public static bool IsAlphabetic(char c) => IsAlphabeticLower(c) || IsAlphabeticUpper(c);
    public static bool IsBetween(char c, char a, char b) => c >= a && c <= b;
}