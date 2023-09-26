using System.Linq;
using Common.Puzzles;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2020.Aoc202002;

public class Aoc202002 : AocPuzzle
{
    public override string Name => "Password Philosophy";

    protected override PuzzleResult RunPart1()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(InputFile);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count, 556);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(InputFile);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count, 605);
    }
}