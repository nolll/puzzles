using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201916;

[Name("Flawed Frequency Transmission")]
public class Aoc201916 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var algorithm1 = new FrequencyAlgorithmPart1(input);
        var result1 = algorithm1.Run(100);

        return new PuzzleResult(result1, "e995b448fd31fb067432b47f11ac0e67");
    }

    public PuzzleResult RunPart2(string input)
    {
        var algorithm2 = new FrequencyAlgorithmPart2(input);
        var result2 = algorithm2.Run(100);

        return new PuzzleResult(result2, "0b00b51e4f1b1d517a2bb16008f7af58");
    }
}