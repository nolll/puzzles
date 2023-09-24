using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Day22;

public class Year2020Day22 : AocPuzzle
{
    public override string Name => "Crab Combat";

    protected override PuzzleResult RunPart1()
    {
        var game = new CardCombatGame(InputFile);
        var score = game.Play();
        return new PuzzleResult(score, 33_400);
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new CardCombatGame(InputFile);
        var score = game.PlayRecursive();
        return new PuzzleResult(score, 33_745);
    }
}