using System.Text;
using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Axeperiment")]
public class Ece202602 : EverybodyEventPuzzle
{
    [Puzzle("d2fc9610d3073f6dd8ea1275714dd9bf")]
    public int Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = 0;
        foreach (var line in lines)
        {
            var numbers = Numbers.IntsFromString(line).Distinct().Order();
            var dictionary = numbers.ToDictionary(k => k, _ => 0);
            var comparisons = line.Split(' ');
            foreach (var comparison in comparisons)
            {
                var n1 = int.Parse(comparison[..1]);
                var n2 = int.Parse(comparison.Substring(2, 1));
                var comp = comparison[1];
                var alloyToIncrease = comp == '>' ? n1 : n2;
                dictionary[alloyToIncrease] += 1;
            }

            sum += int.Parse(string.Concat(dictionary.OrderByDescending(kv => kv.Value).Select(kv => kv.Key.ToString())));
        }

        return sum;
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}