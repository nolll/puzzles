using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202022;

[Name("Crab Combat")]
public class Aoc202022 : AocPuzzle
{
    [Puzzle("1ab0c908e993eb4c76057e745326c12d")]
    public PuzzleResult Part1(string input)
    {
        var game = new CardCombatGame(input);
        var score = game.Play();
        return new PuzzleResult(score);
    }

    [Puzzle("f1c4ea36b08889edb687d00e9dacffcf")]
    public PuzzleResult Part2(string input)
    {
        var game = new CardCombatGame(input);
        var score = game.PlayRecursive();
        return new PuzzleResult(score);
    }
}