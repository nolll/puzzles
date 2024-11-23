namespace Pzl.Aoc;

public static class AocPuzzleParser
{
    public static (int year, int day) ParseYearAndDay(Type t)
    {
        var year = int.Parse(t.Name.Substring(3, 4));
        var day = int.Parse(t.Name.Substring(7, 2).TrimStart('0'));
        
        return (year, day);
    }
}