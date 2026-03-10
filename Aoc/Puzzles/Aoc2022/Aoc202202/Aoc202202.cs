using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

[Name("Rock Paper Scissors")]
public class Aoc202202 : AocPuzzle
{
    [Puzzle("")]
    public PuzzleResult Part1(string input) => 
        new(new RockPaperScissors().Part1(input), "21342a8c13c83a2420368dd586a7a5dd");

    [Puzzle("")]
    public PuzzleResult Part2(string input) => 
        new(new RockPaperScissors().Part2(input), "ee182ab67d32eeac3499142ceeb632c3");
}