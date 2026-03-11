using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler043;

[Name("Sub-string Divisibility")]
public class Euler043 : EulerPuzzle
{
    [Puzzle("0700006fb08f1a62536c94a99b1e1adc")]
    public long Solve()
    {
        int[] divisors = [2, 3, 5, 7, 11, 13, 17];
        var remainingNumbers = Enumerable.Range(0, 10).ToList();

        return FindNumbers("", remainingNumbers, divisors)
            .Select(long.Parse)
            .Sum();
    }

    private static List<string> FindNumbers(string s, List<int> remainingNumbers, int[] divisors)
    {
        var length = s.Length;
        if (length > 3)
        {
            var lastThree = int.Parse(s[^3..]);
            if (lastThree % divisors[length - 4] != 0)
                return [];
        }

        if (!remainingNumbers.Any())
            return [s];

        var list = new List<string>();
        foreach (var n in remainingNumbers)
        {
            list.AddRange(FindNumbers(s + n, remainingNumbers.Where(o => o != n).ToList(), divisors));
        }

        return list;
    }
}