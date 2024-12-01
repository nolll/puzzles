using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202019;

[Name("Monster Messages")]
public class Aoc202019 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var validator = new MonsterImageValidator(input);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "5689e3eed11a233bb204f8f0e2bfe42f");
    }

    public PuzzleResult RunPart2(string input)
    {
        var validator = new MonsterImageValidator(input, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "95d28bbc9dd67fbc8d8db74ab2879177");
    }
}