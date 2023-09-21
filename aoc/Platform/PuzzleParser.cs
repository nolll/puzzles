using System;

namespace Aoc.Platform;

public static class PuzzleParser
{
    public static (int year, int day) GetYearAndDay(Type t)
    {
        var name = t.Name;
        var year = int.Parse(name.Substring(4, 4));
        var day = int.Parse(name.Substring(11, 2).TrimStart('0'));
        return (year, day);
    }
}