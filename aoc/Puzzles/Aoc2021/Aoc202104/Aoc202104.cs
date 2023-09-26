using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202104;

public class Aoc202104 : AocPuzzle
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