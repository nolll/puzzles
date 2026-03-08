using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201615;

[Name("Timing is Everything")]
public class Aoc201615 : AocPuzzle
{
    [Puzzle("c2b25510c1da608c5f3a22a5d84c55dd")]
    public int Part1(string input) => new KineticSculpture(input).TimeToPressButton;

    [Puzzle("7e078d8dabad268a34def302abd59ce8")]
    public int Part2(string input) => new KineticSculpture(input, true).TimeToPressButton;
}