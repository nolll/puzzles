using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202016;

[Name("Ticket Translation")]
public class Aoc202016(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var validator = new TicketValidator();
        var result = validator.GetErrorRate(input);
        return new PuzzleResult(result, "7d78cfbc759526833a4566918a854e5b");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new TicketValidator();
        var result = validator.CalculateAnswer(input);
        return new PuzzleResult(result, "f42f08ba29065a89fd379a7eceb34b50");
    }
}