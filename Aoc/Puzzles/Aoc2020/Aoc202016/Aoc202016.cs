using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202016;

[Name("Ticket Translation")]
public class Aoc202016 : AocPuzzle
{
    [Puzzle("7d78cfbc759526833a4566918a854e5b")]
    public PuzzleResult Part1(string input)
    {
        var validator = new TicketValidator();
        var result = validator.GetErrorRate(input);
        return new PuzzleResult(result);
    }

    [Puzzle("f42f08ba29065a89fd379a7eceb34b50")]
    public PuzzleResult Part2(string input)
    {
        var validator = new TicketValidator();
        var result = validator.CalculateAnswer(input);
        return new PuzzleResult(result);
    }
}