using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201704;

[Name("High-Entropy Passphrases")]
public class Aoc201704 : AocPuzzle
{
    [Puzzle("b3e7e2fe95c58aa22d1f35b7cd9c041a")]
    public int Part1(string input)
    {
        var validator = new PassphraseValidator();
        return validator.GetValidCount1(input);
    }

    [Puzzle("960adf2fc72eac4faf8f3f5de0d2e01a")]
    public int Part2(string input) => new PassphraseValidator().GetValidCount2(input);
}