using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202019;

[Name("Monster Messages")]
public class Aoc202019(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var validator = new MonsterImageValidator(Input);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "5689e3eed11a233bb204f8f0e2bfe42f");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new MonsterImageValidator(Input, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "95d28bbc9dd67fbc8d8db74ab2879177");
    }
}