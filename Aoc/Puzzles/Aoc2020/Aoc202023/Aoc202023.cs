using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202023;

[Name("Crab Cups")]
public class Aoc202023 : AocPuzzle
{
    [Puzzle("060b60050b1b5e81909b30f5b00b81dc")]
    public string Part1(string input)
    {
        var game = new CrabCupsGame(int.Parse(input));
        game.Play(100);
        return game.ResultString;
    }

    [Puzzle("86b2d5ff30f1a76d6a5de3dfc06e89e9")]
    public long Part2(string input)
    {
        var game = new CrabCupsGame(int.Parse(input), true);
        game.Play(10_000_000);
        return game.ResultProduct;
    }
}