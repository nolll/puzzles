namespace Pzl.Tools.Strings;

public static class StringExtensions
{
    public static string Shift(this string s, int steps = 1) => steps < 0
        ? s[-steps..] + s[..-steps]
        : s[^steps..] + s[..^steps];

    public static string ShiftLeft(this string s, int steps = 1) => Shift(s, -steps);
    public static string ShiftRight(this string s, int steps = 1) => Shift(s, steps);

    public static bool IsPalindrome(this string s) => 
        string.Join("", s.Reverse()) == s;

    public static string ReverseString(this string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static bool IsLower(this string s) => s.All(char.IsLower);
    public static bool IsUpper(this string s) => s.All(char.IsUpper);
}