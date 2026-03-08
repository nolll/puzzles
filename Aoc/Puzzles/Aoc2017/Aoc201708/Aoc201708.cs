using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201708;

[Name("I Heard You Like Registers")]
public class Aoc201708 : AocPuzzle
{
    [Puzzle("3c0ff36b6914cd6851601f65f68e9637")]
    public int Part1(string input) => new CpuInstructionCalculator(input).LargestValueAtEnd;

    [Puzzle("e2ede6d54359a751cf2c2bdae941840b")]
    public int Part2(string input) => new CpuInstructionCalculator(input).LargestValueEver;
}