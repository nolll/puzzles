using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201621;

public class Aoc201621 : AocPuzzle
{
    public override string Name => "Scrambled Letters and Hash";

    protected override PuzzleResult RunPart1()
    {
        var scrambler = new StringScrambler(InputFile);
        var scrambled = scrambler.Scramble("abcdefgh");
        return new PuzzleResult(scrambled, "dbfgaehc");
    }

    protected override PuzzleResult RunPart2()
    {
        var scrambler = new StringScrambler(InputFile);
        var unscrambled = scrambler.Unscramble("fbgdceah");
        return new PuzzleResult(unscrambled, "aghfcdeb");
    }
}