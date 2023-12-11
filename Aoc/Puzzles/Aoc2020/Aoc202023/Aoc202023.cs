using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202023;

[Name("Crab Cups")]
public class Aoc202023(string input) : AocPuzzle
{
    private int IntInput => int.Parse(input);

    protected override PuzzleResult RunPart1()
    {
        var game = new CrabCupsGame(IntInput);
        game.Play(100);
        return new PuzzleResult(game.ResultString, "060b60050b1b5e81909b30f5b00b81dc");
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new CrabCupsGame(IntInput, true);
        game.Play(10_000_000);
        return new PuzzleResult(game.ResultProduct, "86b2d5ff30f1a76d6a5de3dfc06e89e9");
    }
}