using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202018;

[Name("Operation Order")]
public class Aoc202018 : AocPuzzle
{
    [Puzzle("4a4cb1e5143143fe556872f0d8ace4bc")]
    public long Part1(string input) => new HomeworkCalculator().SumOfAll(input, MathPrecedence.Order);

    [Puzzle("f4ba1f258e57a75e7a35552abca1311f")]
    public long Part2(string input) => new HomeworkCalculator().SumOfAll(input, MathPrecedence.Addition);
}