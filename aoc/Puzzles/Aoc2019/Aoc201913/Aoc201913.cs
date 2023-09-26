using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201913;

public class Aoc201913 : AocPuzzle
{
    public override string Name => "Care Package";

    protected override PuzzleResult RunPart1()
    {
        var arcade = new Arcade(InputFile);
        arcade.Play();

        return new PuzzleResult(arcade.NumberOfBlockTiles, 226);
    }

    protected override PuzzleResult RunPart2()
    {
        var arcade = new Arcade(InputFile);
        arcade.Play(2);

        return new PuzzleResult(arcade.Score, 10800);
    }
}