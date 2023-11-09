using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201704;

public class Aoc201704 : AocPuzzle
{
    public override string Name => "High-Entropy Passphrases";

    protected override PuzzleResult RunPart1()
    {
        var validator = new PassphraseValidator();
        var validCount1 = validator.GetValidCount1(InputFile);
        return new PuzzleResult(validCount1, "b3e7e2fe95c58aa22d1f35b7cd9c041a");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new PassphraseValidator();
        var validCount2 = validator.GetValidCount2(InputFile);
        return new PuzzleResult(validCount2, "960adf2fc72eac4faf8f3f5de0d2e01a");
    }
}