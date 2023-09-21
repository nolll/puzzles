namespace Euler.Common.Strings;

public static class StringExtensions
{
    public static string Shift(this string s, int steps = 1) => steps < 0
        ? s[-steps..] + s[..-steps]
        : s[^steps..] + s[..^steps];

    public static string ShiftLeft(this string s, int steps = 1) => Shift(s, -steps);
    public static string ShiftRight(this string s, int steps = 1) => Shift(s, steps);

    public static bool IsPalindrome(this string s) => 
        string.Join("", s.Reverse()) == s;
}