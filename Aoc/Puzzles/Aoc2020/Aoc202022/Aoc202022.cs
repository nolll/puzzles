using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202022;

[Name("Crab Combat")]
public class Aoc202022 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var game = new CardCombatGame(input);
        var score = game.Play();
        return new PuzzleResult(score, "1ab0c908e993eb4c76057e745326c12d");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var game = new CardCombatGame(input);
        var score = game.PlayRecursive();
        return new PuzzleResult(score, "f1c4ea36b08889edb687d00e9dacffcf");
    }
}