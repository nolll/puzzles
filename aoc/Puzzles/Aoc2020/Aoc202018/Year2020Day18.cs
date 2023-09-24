using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202018;

public class Year2020Day18 : AocPuzzle
{
    public override string Name => "Operation Order";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(InputFile, MathPrecedence.Order);
        return new PuzzleResult(result, 4_297_397_455_886);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(InputFile, MathPrecedence.Addition);
        return new PuzzleResult(result, 93_000_656_194_428);
    }
}