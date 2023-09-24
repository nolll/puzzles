using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day13;

public class Year2022Day13 : AocPuzzle
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