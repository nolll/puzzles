using Aoc.Platform;

namespace Aoc.Puzzles.Year2022.Day13;

public class Year2022Day13 : Puzzle
{
    public override string Title => "Distress Signal";

    public override PuzzleResult RunPart1()
    {
        var signal = new DistressSignal();
        var result = signal.Part1(FileInput);

        return new PuzzleResult(result, 6568);
    }

    public override PuzzleResult RunPart2()
    {
        var signal = new DistressSignal();
        var result = signal.Part2(FileInput);

        return new PuzzleResult(result, 19493);
    }
}