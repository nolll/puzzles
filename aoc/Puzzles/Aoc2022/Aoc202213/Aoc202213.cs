using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202213;

public class Aoc202213 : AocPuzzle
{
    public override string Name => "Distress Signal";

    protected override PuzzleResult RunPart1()
    {
        var signal = new DistressSignal();
        var result = signal.Part1(InputFile);

        return new PuzzleResult(result, 6568);
    }

    protected override PuzzleResult RunPart2()
    {
        var signal = new DistressSignal();
        var result = signal.Part2(InputFile);

        return new PuzzleResult(result, 19493);
    }
}