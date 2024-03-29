﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202001;

[Name("Report Repair")]
public class Aoc202001(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var sumFinder = new SumFinder(input);
        var numbers1 = sumFinder.FindNumbersThatAddUpTo(Target, 2);
        var product = numbers1.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, "89120e7d60fb863cc69d69128748e52d");
    }

    protected override PuzzleResult RunPart2()
    {
        var sumFinder = new SumFinder(input);
        var numbers = sumFinder.FindNumbersThatAddUpTo(Target, 3);
        var product = numbers.Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, "12c4424e1149b29c37b5be950a3c5939");
    }

    private const int Target = 2020;
}