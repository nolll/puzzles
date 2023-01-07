using System.Linq;
using Core.Common.Strings;
using Core.Platform;

namespace Core.Puzzles.Year2020.Day02;

public class Year2020Day02 : Puzzle
{
    public override string Title => "Password Philosophy";

    public override PuzzleResult RunPart1()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(FileInput);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count, 556);
    }

    public override PuzzleResult RunPart2()
    {
        var validator = new PasswordPolicyValidator();
        var policies = PuzzleInputReader.ReadLines(FileInput);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count, 605);
    }
}