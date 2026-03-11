using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202501;

[Name("Dream Vacation")]
public class FlipFlop202501 : FlipFlopPuzzle
{
    [Puzzle("0334ba105a3a073064c3ca9995045f45")]
    public int Part1(string input) => Parse(input).Select(o => o.Length / 2).Sum();

    [Puzzle("7a49dc21094cb76bcf321ada315495d1")]
    public int Part2(string input) => Parse(input).Select(o => o.Length / 2).Where(o => o % 2 == 0).Sum();

    [Puzzle("9a19b2a44353779e832972f06bb9c09b")]
    public int Part3(string input) => Parse(input).Where(o => !o.Contains('e')).Select(o => o.Length / 2).Sum();

    private static string[] Parse(string input) => input.Split(LineBreaks.Single);
}