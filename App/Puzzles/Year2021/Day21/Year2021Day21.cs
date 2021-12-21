using App.Platform;

namespace App.Puzzles.Year2021.Day21;

public class Year2021Day21 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var game = new DiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result.Result);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}