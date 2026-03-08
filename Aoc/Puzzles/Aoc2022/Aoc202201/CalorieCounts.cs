using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202201;

public class CalorieCounts
{
    private readonly int[] _sums;
    public int TopSum => _sums.Max();
    public int Top3Sum => _sums.OrderByDescending(o => o).Take(3).Sum();

    public CalorieCounts(string input)
    {
        _sums = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .Select(o => o.Sum(int.Parse))
            .ToArray();
    }
}