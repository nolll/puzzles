using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201621;

[Name("Scrambled Letters and Hash")]
public class Aoc201621(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var scrambler = new StringScrambler(input);
        var scrambled = scrambler.Scramble("abcdefgh");
        return new PuzzleResult(scrambled, "d23262df6c0ae121dad862c4941b0e84");
    }

    protected override PuzzleResult RunPart2()
    {
        var scrambler = new StringScrambler(input);
        var unscrambled = scrambler.Unscramble("fbgdceah");
        return new PuzzleResult(unscrambled, "c7601768c42b9f9aa8cbb994da21b9fd");
    }
}