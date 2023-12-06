using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202201;

public class CalorieCounts
{
    private readonly int[] _sums;
    public int TopSum => _sums.Max();
    public int Top3Sum => _sums.OrderByDescending(o => o).Take(3).Sum();

    public CalorieCounts(string input)
    {
        var stringGroups = StringReader.ReadLineGroups(input);
        _sums = stringGroups.Select(o => o.Sum(int.Parse)).ToArray();
    }
}