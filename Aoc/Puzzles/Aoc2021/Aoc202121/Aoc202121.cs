using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202121;

[Name("Dirac Dice")]
public class Aoc202121 : AocPuzzle
{
    [Puzzle("97097680a3e3bcba7ebb46d172476cd9")]
    public PuzzleResult Part1(string input)
    {
        var game = new DiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result.Result);
    }

    [Puzzle("677e241c3997b2a9a5c99891d90399f3")]
    public PuzzleResult Part2(string input)
    {
        var game = new RealDiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result);
    }
}