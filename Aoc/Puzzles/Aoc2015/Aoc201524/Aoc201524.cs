﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201524;

[Name("It Hangs in the Balance")]
public class Aoc201524 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var balancer1 = new PresentBalancer(input, 3);
        return new PuzzleResult(balancer1.QuantumEntanglementOfFirstGroup, "112caddb8448ec5cdd5bfca087f393aa");
    }

    public PuzzleResult Part2(string input)
    {
        var balancer2 = new PresentBalancer(input, 4);
        return new PuzzleResult(balancer2.QuantumEntanglementOfFirstGroup, "d1eb70991c3477542b3499f754799982");
    }
}