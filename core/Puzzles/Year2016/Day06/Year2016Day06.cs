using Core.Platform;

namespace Core.Puzzles.Year2016.Day06;

public class Year2016Day06 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var reader = new RepetitionCodeReader();
        var messageMostCommon = reader.ReadMostCommon(FileInput);
        return new PuzzleResult(messageMostCommon, "ygjzvzib");
    }

    public override PuzzleResult RunPart2()
    {
        var reader = new RepetitionCodeReader();
        var messageLeastCommon = reader.ReadLeastCommon(FileInput);
        return new PuzzleResult(messageLeastCommon, "pdesmnoz");
    }
}