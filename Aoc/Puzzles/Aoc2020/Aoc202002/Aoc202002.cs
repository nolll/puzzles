using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202002;

[Name("Password Philosophy")]
public class Aoc202002 : AocPuzzle
{
    [Puzzle("ebf6e414ef8abc275a90f1a99df980cf")]
    public PuzzleResult Part1(string input)
    {
        var validator = new PasswordPolicyValidator();
        var policies = input.Split(LineBreaks.Single);
        var count = policies.Count(validator.IsValidAccordingToRuleOne);
        return new PuzzleResult(count);
    }

    [Puzzle("0bcc20cf5a222049f20c6e88aa2731a9")]
    public PuzzleResult Part2(string input)
    {
        var validator = new PasswordPolicyValidator();
        var policies = input.Split(LineBreaks.Single);
        var count = policies.Count(validator.IsValidAccordingToRuleTwo);
        return new PuzzleResult(count);
    }
}