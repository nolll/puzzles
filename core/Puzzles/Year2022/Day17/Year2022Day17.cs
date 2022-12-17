using Core.Platform;

namespace Core.Puzzles.Year2022.Day17;

public class Year2022Day17 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var tetris = new Tetris();
        var result = tetris.Run(FileInput, 2022);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        var tetris = new Tetris();
        var result = tetris.Run(FileInput, 1_000_000_000_000);

        return new PuzzleResult(result);
    }
}