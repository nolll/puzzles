using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day16;

public class Year2019Day16 : AocPuzzle
{
    public override string Name => "Flawed Frequency Transmission";

    protected override PuzzleResult RunPart1()
    {
        var algorithm1 = new FrequencyAlgorithmPart1(FileInput);
        var result1 = algorithm1.Run(100);

        return new PuzzleResult(result1, "19944447");
    }

    protected override PuzzleResult RunPart2()
    {
        var algorithm2 = new FrequencyAlgorithmPart2(FileInput);
        var result2 = algorithm2.Run(100);

        return new PuzzleResult(result2, "81207421");
    }
}