using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201801;

public static class IntListReader
{
    public static List<int> Read(string str)
    {
        return PuzzleInputReader.ReadLines(str).Select(ConvertToInt).ToList();
    }

    private static int ConvertToInt(string str)
    {
        return int.Parse(str);
    }
}