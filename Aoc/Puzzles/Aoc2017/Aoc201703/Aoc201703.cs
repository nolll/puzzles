using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201703;

[Name("Spiral Memory")]
public class Aoc201703 : AocPuzzle
{
    [Puzzle("748d6bb1c2e5af3bdc9deece20b7d9f5")]
    public int Part1(string input) => new SpiralMemory(int.Parse(input), SpiralMemoryMode.RunToTarget).Distance;

    [Puzzle("5378201bd68f309919ec6a47cde9888d")]
    public long Part2(string input) => new SpiralMemory(int.Parse(input), SpiralMemoryMode.RunToValue).Value;
}