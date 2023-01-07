using Core.Platform;

namespace Core.Puzzles.Year2022.Day02;

public class Year2022Day02 : Puzzle
{
    public override string Title => "Rock Paper Scissors";

    public override PuzzleResult RunPart1()
    {
        var game = new RockPaperScissors();
        var result = game.Part1(FileInput);
        return new PuzzleResult(result, 12586);
    }

    public override PuzzleResult RunPart2()
    {
        var game = new RockPaperScissors();
        var result = game.Part2(FileInput);
        return new PuzzleResult(result, 13193);
    }
}