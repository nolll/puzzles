using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202018;

[Name("Operation Order")]
public class Aoc202018 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(input, MathPrecedence.Order);
        return new PuzzleResult(result, "4a4cb1e5143143fe556872f0d8ace4bc");
    }

    public PuzzleResult RunPart2(string input)
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(input, MathPrecedence.Addition);
        return new PuzzleResult(result, "f4ba1f258e57a75e7a35552abca1311f");
    }
}