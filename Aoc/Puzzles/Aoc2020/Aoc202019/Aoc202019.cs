using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202019;

[Name("Monster Messages")]
public class Aoc202019 : AocPuzzle
{
    [Puzzle("5689e3eed11a233bb204f8f0e2bfe42f")]
    public PuzzleResult Part1(string input)
    {
        var validator = new MonsterImageValidator(input);
        var result = validator.ValidCount();
        return new PuzzleResult(result);
    }

    [Puzzle("95d28bbc9dd67fbc8d8db74ab2879177")]
    public PuzzleResult Part2(string input)
    {
        var validator = new MonsterImageValidator(input, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result);
    }
}