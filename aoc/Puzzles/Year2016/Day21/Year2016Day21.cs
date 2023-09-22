using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day21;

public class Year2016Day21 : AocPuzzle
{
    public override string Name => "Scrambled Letters and Hash";

    protected override PuzzleResult RunPart1()
    {
        var scrambler = new StringScrambler(FileInput);
        var scrambled = scrambler.Scramble("abcdefgh");
        return new PuzzleResult(scrambled, "dbfgaehc");
    }

    protected override PuzzleResult RunPart2()
    {
        var scrambler = new StringScrambler(FileInput);
        var unscrambled = scrambler.Unscramble("fbgdceah");
        return new PuzzleResult(unscrambled, "aghfcdeb");
    }
}