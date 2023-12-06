using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202016;

public class Aoc202016 : AocPuzzle
{
    public override string Name => "Ticket Translation";

    protected override PuzzleResult RunPart1()
    {
        var validator = new TicketValidator();
        var result = validator.GetErrorRate(InputFile);
        return new PuzzleResult(result, "7d78cfbc759526833a4566918a854e5b");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new TicketValidator();
        var result = validator.CalculateAnswer(InputFile);
        return new PuzzleResult(result, "f42f08ba29065a89fd379a7eceb34b50");
    }
}