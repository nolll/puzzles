using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("The Treachery of Whales")]
public class Aoc202107 : AocPuzzle
{
    [Puzzle("666d31015d60e4cd37891ed574d5227f")]
    public int Part1(string input) => Solve(input, GetCost);

    [Puzzle("7930686503708646dfb6d7f6a7e36ab2")]
    public int Part2(string input) => Solve(input, GetCrabEnginerringCost);

    private static int Solve(string input, Func<int, int, int> getCost)
    {
        var minCost = int.MaxValue;
        var positions = input.Split(',').Select(int.Parse).ToArray();
        var maxPos = positions.Max();
        for (var i = 0; i < maxPos; i++)
        {
            minCost = Math.Min(positions.Sum(o => getCost(i, o)), minCost);
        }

        return minCost;
    }

    private static int GetCost(int a, int b) => GetDiff(a, b);

    private static int GetCrabEnginerringCost(int a, int b)
    {
        var diff = GetDiff(a, b);
        return diff * (diff + 1) / 2;
    }

    private static int GetDiff(int a, int b) => Math.Max(a, b) - Math.Min(a, b);
}