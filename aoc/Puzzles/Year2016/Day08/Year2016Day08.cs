using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day08;

public class Year2016Day08 : AocPuzzle
{
    public override string Name => "Two-Factor Authentication";

    public override PuzzleResult RunPart1()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(FileInput);
        return new PuzzleResult(simulatorResult.PixelCount, 121);
    }

    public override PuzzleResult RunPart2()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(FileInput);
        return new PuzzleResult(simulatorResult.Letters, "RURUCEOEIL");
    }
}