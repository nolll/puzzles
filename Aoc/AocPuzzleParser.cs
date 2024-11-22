namespace Pzl.Aoc;

public static class AocPuzzleParser
{
    public static (int year, int day) GetYearAndDay(Type t)
    {
        var name = t.Name;
        var isLegacy = name.Contains("Year");
        
        var year = isLegacy
            ? int.Parse(name.Substring(4, 4))
            : int.Parse(name.Substring(3, 4));

        var day = isLegacy
            ? int.Parse(name.Substring(11, 2).TrimStart('0'))
            : int.Parse(name.Substring(7, 2).TrimStart('0'));
        
        return (year, day);
    }
}