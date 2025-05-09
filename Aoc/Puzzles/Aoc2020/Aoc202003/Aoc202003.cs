﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202003;

[Name("Toboggan Trajectory")]
public class Aoc202003 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var navigator = new TreeNavigator(input);
        var treeCount = navigator.GetSingleTreeCount();
        return new PuzzleResult(treeCount, "5523923bd52d76e1c1d68b1cfdff95b5");
    }

    public PuzzleResult RunPart2(string input)
    {
        var navigator = new TreeNavigator(input);
        var treeCounts = navigator.GetAllTreeCounts().ToList();
        var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
        return new PuzzleResult(product, "2429f66aeab700cdc54b44c6b498a22b");
    }
}