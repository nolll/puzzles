using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day02;

public class Year2022Day02 : AocPuzzle
{
    public override string Name => "Rock Paper Scissors";

    protected override PuzzleResult RunPart1()
    {
        var game = new RockPaperScissors();
        var result = game.Part1(InputFile);
        return new PuzzleResult(result, 12586);
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new RockPaperScissors();
        var result = game.Part2(InputFile);
        return new PuzzleResult(result, 13193);
    }
}