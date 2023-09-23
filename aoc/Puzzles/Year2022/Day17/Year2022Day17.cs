using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day17;

public class Year2022Day17 : AocPuzzle
{
    public override string Name => "Pyroclastic Flow";

    protected override PuzzleResult RunPart1()
    {
        var tetris = new Tetris();
        var result = tetris.Run(InputFile, 2022);

        return new PuzzleResult(result, 3197);
    }

    protected override PuzzleResult RunPart2()
    {
        var tetris = new Tetris();
        var result = tetris.Run(InputFile, 1_000_000_000_000);

        return new PuzzleResult(result, 1_568_513_119_571);
    }
}   