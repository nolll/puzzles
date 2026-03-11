using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202213;

[Name("Distress Signal")]
public class Aoc202213 : AocPuzzle
{
    [Puzzle("b7ce4fc8127f3ae910077459ccdd2466")]
    public PuzzleResult Part1(string input)
    {
        var signal = new DistressSignal();
        var result = signal.Part1(input);

        return new PuzzleResult(result);
    }

    [Puzzle("dae06225ebac50b689604b2ca86cfabf")]
    public PuzzleResult Part2(string input)
    {
        var signal = new DistressSignal();
        var result = signal.Part2(input);

        return new PuzzleResult(result);
    }
}