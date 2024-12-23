using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

[Name("Rock Paper Scissors")]
public class Aoc202202 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var game = new RockPaperScissors();
        var result = game.Part1(input);
        return new PuzzleResult(result, "21342a8c13c83a2420368dd586a7a5dd");
    }

    public PuzzleResult RunPart2(string input)
    {
        var game = new RockPaperScissors();
        var result = game.Part2(input);
        return new PuzzleResult(result, "ee182ab67d32eeac3499142ceeb632c3");
    }
}