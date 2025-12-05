using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202505;

[Name("Cafeteria")]
public class Aoc202505 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (rangeInput, numberInput) = input.Split(LineBreaks.Double);
        var ranges = GetRanges(rangeInput);
        var numbers = numberInput.Split(LineBreaks.Single).Select(long.Parse);
        var count = numbers.Count(n => ranges.Any(r => n >= r[0] && n <= r[1]));
        return new PuzzleResult(count, "a90b6ec9ee3627fb518f272a19fb02f7");
    }

    public PuzzleResult Part2(string input)
    {
        var rangeInput = input.Split(LineBreaks.Double).First();
        var count = GetRanges(rangeInput).Sum(range => range[1] - range[0] + 1);
        return new PuzzleResult(count, "be06dfd5fc2345c5df5b1b53d430fff5");
    }

    private List<long[]> GetRanges(string rangeInput)
    {
        var ranges = rangeInput
            .Split(LineBreaks.Single)
            .Select(o => o.Split('-').Select(long.Parse).ToArray())
            .OrderBy(o => o[0])
            .ToList();
        
        var removed = ranges.Select(_ => false).ToArray();
        for (var i = 0; i < ranges.Count; i++)
        {
            if (removed[i]) continue;
            var currentRange = ranges[i];
            var cmin = currentRange[0];
            var cmax = currentRange[1];
            for (var j = 0; j < ranges.Count; j++)
            {
                if (i == j) continue;
                if (removed[j]) continue;
                
                var otherRange = ranges[j];
                var omin = otherRange[0];
                var omax = otherRange[1];
                var isOverlapping = omin >= cmin && omin <= cmax || omax >= cmin && omax <= cmax;
                var currentContainsOther = omin >= cmin && omax <= cmax;
                var otherContainsCurrent = cmin >= omin && cmax <= omax;
                if (!isOverlapping && !currentContainsOther && !otherContainsCurrent) continue;
                
                cmin = Math.Min(cmin, omin);
                cmax = Math.Max(cmax, omax);
                removed[j] = true;
            }

            ranges[i] = [cmin, cmax];
        }

        return ranges.Where((_, i) => !removed[i]).ToList();
    }
}