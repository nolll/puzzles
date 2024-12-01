using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201712;

[Name("Digital Plumber")]
public class Aoc201712 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var pipes = new Pipes(input);
        return new PuzzleResult(pipes.PipesInGroupZero, "4d7ad96354959558ed0b95fa70be777c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var pipes = new Pipes(input);
        return new PuzzleResult(pipes.GroupCount, "0dadeecc2db53e7a3420661be4101b8f");
    }
}