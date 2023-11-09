using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201916;

public class Aoc201916 : AocPuzzle
{
    public override string Name => "Flawed Frequency Transmission";

    protected override PuzzleResult RunPart1()
    {
        var algorithm1 = new FrequencyAlgorithmPart1(InputFile);
        var result1 = algorithm1.Run(100);

        return new PuzzleResult(result1, "e995b448fd31fb067432b47f11ac0e67");
    }

    protected override PuzzleResult RunPart2()
    {
        var algorithm2 = new FrequencyAlgorithmPart2(InputFile);
        var result2 = algorithm2.Run(100);

        return new PuzzleResult(result2, "0b00b51e4f1b1d517a2bb16008f7af58");
    }
}