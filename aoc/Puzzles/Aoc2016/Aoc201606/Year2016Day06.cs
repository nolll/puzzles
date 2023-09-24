using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201606;

public class Year2016Day06 : AocPuzzle
{
    public override string Name => "Signals and Noise";

    protected override PuzzleResult RunPart1()
    {
        var reader = new RepetitionCodeReader();
        var messageMostCommon = reader.ReadMostCommon(InputFile);
        return new PuzzleResult(messageMostCommon, "ygjzvzib");
    }

    protected override PuzzleResult RunPart2()
    {
        var reader = new RepetitionCodeReader();
        var messageLeastCommon = reader.ReadLeastCommon(InputFile);
        return new PuzzleResult(messageLeastCommon, "pdesmnoz");
    }
}