using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day04;

public class Year2021Day04 : AocPuzzle
{
    public override string Name => "Giant Squid";

    public override PuzzleResult RunPart1()
    {
        var diagnostics = new BingoGame(FileInput);
        var result = diagnostics.Play(false);

        return new PuzzleResult(result, 45031);
    }

    public override PuzzleResult RunPart2()
    {
        var diagnostics = new BingoGame(FileInput);
        var result = diagnostics.Play(true);

        return new PuzzleResult(result, 2568);
    }
}