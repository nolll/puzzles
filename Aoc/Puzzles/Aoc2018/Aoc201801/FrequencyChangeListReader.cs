namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

public static class FrequencyChangeListReader
{
    public static List<int> Read(string str)
    {
        return IntListReader.Read(RemovePlusSigns(str)).ToList();
    }

    private static string RemovePlusSigns(string input)
    {
        return input.Replace("+", "");
    }
}