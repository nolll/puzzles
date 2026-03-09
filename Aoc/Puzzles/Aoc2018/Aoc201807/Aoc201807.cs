using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201807;

[Name("The Sum of Its Parts")]
public class Aoc201807 : AocPuzzle
{
    [Puzzle("ed793c91fc1d9c9e6a4828232e0a8c2b")]
    public string Part1(string input) => new SleighAssembler(input, 1, 0).Assemble().Order;

    [Puzzle("c0599783d1840d6a6a7350bc40af4377")]
    public int Part2(string input) => new SleighAssembler(input, 5, 60).Assemble().Time;
}