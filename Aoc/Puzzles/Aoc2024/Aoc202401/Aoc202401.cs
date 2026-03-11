using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202401;

[Name("Historian Hysteria")]
public class Aoc202401 : AocPuzzle
{
    [Puzzle("1683d6a6faf4595fa01c5ba3662aa084")]
    public int Part1(string input)
    {
        var (left, right) = ParseLists(input);
        return left.Select((t, i) => Math.Abs(t - right[i])).Sum();
    }

    [Puzzle("027fe2da3467811e48fa3528e6fbcab4")]
    public long Part2(string input)
    {
        var (left, right) = ParseLists(input);
        return left.Aggregate(0L, (similarity, n) => similarity + right.Count(o => o == n) * n);
    }

    private static (int[], int[]) ParseLists(string input)
    {
        var pairs = input.Split(LineBreaks.Single)
            .Select(o => o.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        var left = pairs.Select(o => int.Parse(o[0])).Order().ToArray();
        var right = pairs.Select(o => int.Parse(o[1])).Order().ToArray();

        return (left, right);
    }
}