using System.Linq;
using common.Strings;

namespace Aoc.Puzzles.Year2022.Day01;

public class CalorieCounts
{
    private readonly int[] _sums;
    public int TopSum => _sums.Max();
    public int Top3Sum => _sums.OrderByDescending(o => o).Take(3).Sum();

    public CalorieCounts(string input)
    {
        var stringGroups = PuzzleInputReader.ReadLineGroups(input);
        _sums = stringGroups.Select(o => o.Sum(int.Parse)).ToArray();
    }
}