using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202023;

public class Aoc202023 : AocPuzzle
{
    public override string Name => "Crab Cups";

    protected override PuzzleResult RunPart1()
    {
        var game = new CrabCupsGame(Input);
        game.Play(100);
        return new PuzzleResult(game.ResultString, "060b60050b1b5e81909b30f5b00b81dc");
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new CrabCupsGame(Input, true);
        game.Play(10_000_000);
        return new PuzzleResult(game.ResultProduct, "86b2d5ff30f1a76d6a5de3dfc06e89e9");
    }

    private const int Input = 952316487;
}