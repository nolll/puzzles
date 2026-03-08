using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201606;

[Name("Signals and Noise")]
public class Aoc201606 : AocPuzzle
{
    [Puzzle("d501463dd43fdef3d85d722210ab3940")]
    public string Part1(string input) => new RepetitionCodeReader().ReadMostCommon(input);

    [Puzzle("509675b487b1cf475001b9592fab4a95")]
    public string Part2(string input) => new RepetitionCodeReader().ReadLeastCommon(input);
}