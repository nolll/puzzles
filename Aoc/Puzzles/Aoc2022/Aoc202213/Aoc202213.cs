using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202213;

[Name("Distress Signal")]
public class Aoc202213 : AocPuzzle
{
    [Puzzle("b7ce4fc8127f3ae910077459ccdd2466")]
    public int Part1(string input) => new DistressSignal().Part1(input);

    [Puzzle("dae06225ebac50b689604b2ca86cfabf")]
    public int Part2(string input) => new DistressSignal().Part2(input);
}