using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Calibration")]
public class Aoc201801 : AocPuzzle
{
    [Puzzle("6161dde7fc767cd20548aa2a500b6af4")]
    public int Part1(string input) => Parse(input).Sum();

    [Puzzle("fba794668dca2e1a271d8ead203f36d2")]
    public int Part2(string input) => GetFirstRepeat(Parse(input));

    private static int GetFirstRepeat(List<int> changes)
    {
        var sum = 0;
        var uniqueResults = new List<int> { sum };
        int? firstRepeat = null;
        while (firstRepeat == null)
        {
            foreach (var change in changes)
            {
                sum += change;
                if (uniqueResults.Contains(sum))
                {
                    firstRepeat = sum;
                    break;
                }
                uniqueResults.Add(sum);
            }
        }
        return (int)firstRepeat;
    }

    private static List<int> Parse(string str) => [.. str.Replace("+", "").Split(LineBreaks.Single).Select(int.Parse)];
}