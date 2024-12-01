using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201704;

[Name("High-Entropy Passphrases")]
public class Aoc201704 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var validator = new PassphraseValidator();
        var validCount1 = validator.GetValidCount1(input);
        return new PuzzleResult(validCount1, "b3e7e2fe95c58aa22d1f35b7cd9c041a");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var validator = new PassphraseValidator();
        var validCount2 = validator.GetValidCount2(input);
        return new PuzzleResult(validCount2, "960adf2fc72eac4faf8f3f5de0d2e01a");
    }
}