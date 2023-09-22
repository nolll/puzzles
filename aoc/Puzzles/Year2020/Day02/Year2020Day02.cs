using System.Linq;
using Aoc.Platform;
using common.Puzzles;
using common.Strings;

namespace Aoc.Puzzles.Year2020.Day02;

public class Year2020Day02 : AocPuzzle
{
    public override string Name => "Password Philosophy";

    protected override PuzzleResult RunPart1()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(FileInput);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count, 556);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(FileInput);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count, 605);
    }
}