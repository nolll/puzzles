using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201809;

[Name("Marble Mania")]
public class Aoc201809 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var game = MarbleGame.Parse(InputFile);
        return new PuzzleResult(game.WinnerScore, "dab82e0990c953b88e3617b646bc089a");
    }

    protected override PuzzleResult RunPart2()
    {
        var game2 = MarbleGame.Parse(InputFile, 100);
        return new PuzzleResult(game2.WinnerScore, "efdea08bc5ee63512ba8659f1d13e63c");
    }
}