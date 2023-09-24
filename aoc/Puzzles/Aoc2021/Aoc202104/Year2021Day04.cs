using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Day04;

public class Year2021Day04 : AocPuzzle
{
    public override string Name => "Giant Squid";

    protected override PuzzleResult RunPart1()
    {
        var diagnostics = new BingoGame(InputFile);
        var result = diagnostics.Play(false);

        return new PuzzleResult(result, 45031);
    }

    protected override PuzzleResult RunPart2()
    {
        var diagnostics = new BingoGame(InputFile);
        var result = diagnostics.Play(true);

        return new PuzzleResult(result, 2568);
    }
}