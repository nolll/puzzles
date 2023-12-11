using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201916;

[Name("Flawed Frequency Transmission")]
public class Aoc201916(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var algorithm1 = new FrequencyAlgorithmPart1(Input);
        var result1 = algorithm1.Run(100);

        return new PuzzleResult(result1, "e995b448fd31fb067432b47f11ac0e67");
    }

    protected override PuzzleResult RunPart2()
    {
        var algorithm2 = new FrequencyAlgorithmPart2(Input);
        var result2 = algorithm2.Run(100);

        return new PuzzleResult(result2, "0b00b51e4f1b1d517a2bb16008f7af58");
    }
}