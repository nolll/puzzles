﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202010;

[Name("Adapter Array")]
public class Aoc202010(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var chain = new PowerAdapterChain(input);
        return new PuzzleResult(chain.DifferenceProduct, "56be819907a3ccd3fa53c9340c9cd2b7");
    }

    protected override PuzzleResult RunPart2()
    {
        var chain = new PowerAdapterChain(input);
        var combinations = chain.GetTotalNumberOfCombinations();
        return new PuzzleResult(combinations, "791600ed80a4c8e120ae60a88193043f");
    }
}