using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

[Name("Aunt Sue")]
public class Aoc201516 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sues = ParseSues(input);
        var correctSuePart1 = sues.FirstOrDefault(o => o.IsCorrectSuePart1);
        var result = correctSuePart1?.Number ?? 0;
        return new PuzzleResult(result, "fc9e347f58cd62a8056800cedf1772ff");
    }

    public PuzzleResult Part2(string input)
    {
        var sues = ParseSues(input);
        var correctSuePart2 = sues.FirstOrDefault(o => o.IsCorrectSuePart2);
        var result = correctSuePart2?.Number ?? 0;
        return new PuzzleResult(result, "d0cfc435d1459e83bcc2be3046271a1a");
    }
    
    private static IList<Sue> ParseSues(string input) => input.Split(LineBreaks.Single).Select(ParseSue).ToList();

    private static Sue ParseSue(string s)
    {
        var parts = s.Replace(":", "").Replace(",", "").Split(' ');
        var number = int.Parse(parts[1]);
        var sue = new Sue(number);
        sue.Set(parts[2], int.Parse(parts[3]));
        sue.Set(parts[4], int.Parse(parts[5]));
        sue.Set(parts[6], int.Parse(parts[7]));
        return sue;
    }
}