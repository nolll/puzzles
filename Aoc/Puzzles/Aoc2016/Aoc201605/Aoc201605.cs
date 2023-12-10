using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201605;

[Name("How About a Nice Game of Chess?")]
public class Aoc201605 : AocPuzzle
{
    private readonly PasswordGenerator _generator = new();

    protected override PuzzleResult RunPart1()
    {
        var pwd = _generator.Generate1(Input);
        return new PuzzleResult(pwd, "40c5b62ed7b9f223838482c66c629a2a");
    }

    protected override PuzzleResult RunPart2()
    {
        var pwd = _generator.Generate2(Input);
        return new PuzzleResult(pwd, "73bc206f743ba68d2e5dea0e9fbf96a4");
    }

    private static string Input => "wtnhxymk";
}