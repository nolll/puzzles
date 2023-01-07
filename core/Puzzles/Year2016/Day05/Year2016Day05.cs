using Core.Platform;

namespace Core.Puzzles.Year2016.Day05;

public class Year2016Day05 : Puzzle
{
    private readonly PasswordGenerator _generator = new();

    public override string Title => "How About a Nice Game of Chess?";

    public override PuzzleResult RunPart1()
    {
        var pwd = _generator.Generate1(Input);
        return new PuzzleResult(pwd, "2414bc77");
    }

    public override PuzzleResult RunPart2()
    {
        var pwd = _generator.Generate2(Input);
        return new PuzzleResult(pwd, "437e60fc");
    }

    private static string Input => "wtnhxymk";
}