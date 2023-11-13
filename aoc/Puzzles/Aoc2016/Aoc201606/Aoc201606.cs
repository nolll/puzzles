using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201606;

public class Aoc201606 : AocPuzzle
{
    public override string Name => "Signals and Noise";

    protected override PuzzleResult RunPart1()
    {
        var reader = new RepetitionCodeReader();
        var messageMostCommon = reader.ReadMostCommon(InputFile);
        return new PuzzleResult(messageMostCommon, "d501463dd43fdef3d85d722210ab3940");
    }

    protected override PuzzleResult RunPart2()
    {
        var reader = new RepetitionCodeReader();
        var messageLeastCommon = reader.ReadLeastCommon(InputFile);
        return new PuzzleResult(messageLeastCommon, "509675b487b1cf475001b9592fab4a95");
    }
}