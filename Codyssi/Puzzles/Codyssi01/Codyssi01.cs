using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi01;

[Name("Compass Calibration")]
public class Codyssi01 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single).ToList();
        var numbers = lines.SkipLast(1).Select(int.Parse).ToArray();
        var multipliers = GetMultipliers(lines.Last());
        var n = multipliers.Select((t, i) => numbers[i] * t).Sum();

        return new PuzzleResult(n, "1f17ebbf90b3d2771a89172125b9fcb0");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single).ToList();
        var numbers = lines.SkipLast(1).Select(int.Parse).ToArray();
        var multipliers = GetMultipliers(lines.Last().Reversed());
        var n = multipliers.Select((t, i) => numbers[i] * t).Sum();

        return new PuzzleResult(n, "d79852c3963ccb64147853df691ef1cf");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single).ToList();
        var digits = lines.SkipLast(1).ToArray();
        var numbers = new List<int>();
        for (var i = 0; i < digits.Length; i += 2)
        {
            numbers.Add(int.Parse($"{digits[i]}{digits[i + 1]}"));
        }
        var multipliers = GetMultipliers(lines.Last().Reversed());
        var n = numbers.Select((t, i) => t * multipliers[i]).Sum();

        return new PuzzleResult(n, "7e2613ac221549d96730491340a1b69e");
    }
    
    private static IEnumerable<int> GetMultipliers(string s) => GetMultipliers(s.ToCharArray());
    private static int[] GetMultipliers(IEnumerable<char> s) => [1, ..s.Select(o => o is '+' ? 1 : -1)];
}