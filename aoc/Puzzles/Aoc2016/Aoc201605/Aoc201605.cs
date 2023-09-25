using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201605;

public class Aoc201605 : AocPuzzle
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