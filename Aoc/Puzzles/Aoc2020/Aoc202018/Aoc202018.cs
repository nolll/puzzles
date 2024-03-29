﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202018;

[Name("Operation Order")]
public class Aoc202018(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(input, MathPrecedence.Order);
        return new PuzzleResult(result, "4a4cb1e5143143fe556872f0d8ace4bc");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new HomeworkCalculator();
        var result = calculator.SumOfAll(input, MathPrecedence.Addition);
        return new PuzzleResult(result, "f4ba1f258e57a75e7a35552abca1311f");
    }
}