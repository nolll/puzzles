using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

public static class IntListReader
{
    public static List<int> Read(string str)
    {
        return StringReader.ReadLines(str).Select(ConvertToInt).ToList();
    }

    private static int ConvertToInt(string str)
    {
        return int.Parse(str);
    }
}