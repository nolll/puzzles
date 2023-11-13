using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201712;

public class Aoc201712 : AocPuzzle
{
    public override string Name => "Digital Plumber";

    protected override PuzzleResult RunPart1()
    {
        var pipes = new Pipes(InputFile);
        return new PuzzleResult(pipes.PipesInGroupZero, "4d7ad96354959558ed0b95fa70be777c");
    }

    protected override PuzzleResult RunPart2()
    {
        var pipes = new Pipes(InputFile);
        return new PuzzleResult(pipes.GroupCount, "0dadeecc2db53e7a3420661be4101b8f");
    }
}