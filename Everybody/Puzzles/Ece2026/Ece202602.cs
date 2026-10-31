using Pzl.Common;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

// Got a little help from Jonathan Paulson with the filling of missing comparisons
[Name("The Axeperiment")]
public class Ece202602 : EverybodyEventPuzzle
{
    [Puzzle("d2fc9610d3073f6dd8ea1275714dd9bf")]
    public long Part1(string input) => Solve(input);

    [Puzzle("3ed41a314b7fa0ba8eaa2d15297745e9")]
    public long Part2(string input) => Solve(input);

    [Puzzle("71958f7da629b8d9ae7c4bd8e6d8e250")]
    public long Part3(string input) => Solve(input);

    private static long Solve(string input) => input.Split(LineBreaks.Single).Sum(SolveLine);

    private static long SolveLine(string line)
    {

        var numbers = new HashSet<int>();
        var isSmaller = new HashSet<(int smaller, int larger)>();
        var comparisons = line.Split(' ');
        foreach (var comparison in comparisons)
        {
            var left = int.Parse(comparison[..1]);
            var right = int.Parse(comparison.Substring(2, 1));
            numbers.AddRange([left, right]);
            var comp = comparison[1];
            var larger = comp == '>' ? left : right;
            var smaller = comp == '>' ? right : left;
            isSmaller.Add((smaller, larger));
        }

        FillMissingComparisons(numbers, isSmaller);
        
        var sorted = numbers.OrderDescending(new Comparer(isSmaller)).ToList();
        
        return long.Parse(string.Concat(sorted.Select(o => o.ToString())));
    }

    private static void FillMissingComparisons(HashSet<int> numbers, HashSet<(int smaller, int larger)> isSmaller)
    {
        foreach (var k in numbers)
        {
            foreach (var a in numbers)
            {
                foreach (var b in numbers)
                {
                    if (isSmaller.Contains((a, k)) && isSmaller.Contains((k, b)))
                    {
                        isSmaller.Add((a, b));
                    }
                }
            }
        }
    }

    private class Comparer(HashSet<(int smaller, int larger)> isSmaller) : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (isSmaller.Contains((a, b)))
                return -1;

            if (a == b)
                return 0;

            return 1;
        }
    }
}