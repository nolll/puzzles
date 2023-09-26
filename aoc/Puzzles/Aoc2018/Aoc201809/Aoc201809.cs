using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201809;

public class Aoc201809 : AocPuzzle
{
    public override string Name => "Marble Mania";

    protected override PuzzleResult RunPart1()
    {
        var game = MarbleGame.Parse(InputFile);
        return new PuzzleResult(game.WinnerScore, 434_674);
    }

    protected override PuzzleResult RunPart2()
    {
        var game2 = MarbleGame.Parse(InputFile, 100);
        return new PuzzleResult(game2.WinnerScore, 3_653_994_575);
    }
}