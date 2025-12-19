using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202501;

[Name("Dream Vacation")]
public class FlipFlop202501 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select(o => o.Length / 2).Sum();
        return new PuzzleResult(sum, "0334ba105a3a073064c3ca9995045f45");
    }

    public PuzzleResult Part2(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select(o => o.Length / 2).Where(o => o % 2 == 0).Sum();
        return new PuzzleResult(sum, "7a49dc21094cb76bcf321ada315495d1");
    }

    public PuzzleResult Part3(string input)
    {
        var sum = input.Split(LineBreaks.Single).Where(o => !o.Contains('e')).Select(o => o.Length / 2).Sum();
        return new PuzzleResult(sum, "9a19b2a44353779e832972f06bb9c09b");
    }
}