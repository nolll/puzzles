using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day23;

public class Year2020Day23 : AocPuzzle
{
    public override string Name => "Crab Cups";

    protected override PuzzleResult RunPart1()
    {
        var game = new CrabCupsGame(Input);
        game.Play(100);
        return new PuzzleResult(game.ResultString, "25398647");
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new CrabCupsGame(Input, true);
        game.Play(10_000_000);
        return new PuzzleResult(game.ResultProduct, 363_807_398_885);
    }

    private const int Input = 952316487;
}