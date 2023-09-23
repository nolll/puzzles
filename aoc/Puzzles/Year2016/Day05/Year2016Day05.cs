using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day05;

public class Year2016Day05 : AocPuzzle
{
    private readonly PasswordGenerator _generator = new();

    public override string Name => "How About a Nice Game of Chess?";

    protected override PuzzleResult RunPart1()
    {
        var pwd = _generator.Generate1(Input);
        return new PuzzleResult(pwd, "2414bc77");
    }

    protected override PuzzleResult RunPart2()
    {
        var pwd = _generator.Generate2(Input);
        return new PuzzleResult(pwd, "437e60fc");
    }

    private static string Input => "wtnhxymk";
}