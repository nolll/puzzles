using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202002;

public class Aoc202002 : AocPuzzle
{
    public override string Name => "Password Philosophy";

    protected override PuzzleResult RunPart1()
    {
        var validator = new PasswordPolicyValidator();
        var policies = StringReader.ReadLines(InputFile);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count, "ebf6e414ef8abc275a90f1a99df980cf");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new PasswordPolicyValidator();
        var policies = StringReader.ReadLines(InputFile);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count, "0bcc20cf5a222049f20c6e88aa2731a9");
    }
}