using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201712;

[Name("Digital Plumber")]
public class Aoc201712 : AocPuzzle
{
    [Puzzle("4d7ad96354959558ed0b95fa70be777c")]
    public int Part1(string input) => new Pipes(input).PipesInGroupZero;

    [Puzzle("0dadeecc2db53e7a3420661be4101b8f")]
    public int Part2(string input) => new Pipes(input).GroupCount;
}