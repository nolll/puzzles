using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202202;

public class Aoc202202 : AocPuzzle
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