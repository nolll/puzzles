using App.Platform;

namespace App.Puzzles.Year2020.Day22;

public class Year2020Day22 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var game = new CardCombatGame(FileInput);
        var score = game.Play();
        return new PuzzleResult(score, 33_400);
    }

    public override PuzzleResult RunPart2()
    {
        var game = new CardCombatGame(FileInput);
        var score = game.PlayRecursive();
        return new PuzzleResult(score, 33_745);
    }
}