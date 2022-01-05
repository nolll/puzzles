using App.Platform;

namespace App.Puzzles.Year2019.Day13;

public class Year2019Day13 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var arcade = new Arcade(FileInput);
        arcade.Play();

        return new PuzzleResult(arcade.NumberOfBlockTiles, 226);
    }

    public override PuzzleResult RunPart2()
    {
        var arcade = new Arcade(FileInput);
        arcade.Play(2);

        return new PuzzleResult(arcade.Score, 10800);
    }
}