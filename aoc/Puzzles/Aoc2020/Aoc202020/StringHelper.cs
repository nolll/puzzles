using System;

namespace Aoc.Puzzles.Aoc2020.Aoc202020;

public static class StringHelper
{
    public static string Reverse(this string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}