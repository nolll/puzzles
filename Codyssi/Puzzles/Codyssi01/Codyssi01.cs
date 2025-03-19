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
        var multipliers = lines.Last().ToCharArray().Select(o => o is '+' ? 1 : -1).ToArray();
        var n = numbers.First();

        for (var i = 0; i < multipliers.Length; i++)
        {
            n += numbers[i + 1] * multipliers[i];
        }
        
        return new PuzzleResult(n, "1f17ebbf90b3d2771a89172125b9fcb0");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}