using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202002;

[Name("Password Philosophy")]
public class Aoc202002 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var validator = new PasswordPolicyValidator();
        var policies = StringReader.ReadLines(input);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count, "ebf6e414ef8abc275a90f1a99df980cf");
    }

    public PuzzleResult RunPart2(string input)
    {
        var validator = new PasswordPolicyValidator();
        var policies = StringReader.ReadLines(input);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count, "0bcc20cf5a222049f20c6e88aa2731a9");
    }
}