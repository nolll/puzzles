using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201608;

public class Aoc201608 : AocPuzzle
{
    public override string Name => "Two-Factor Authentication";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(InputFile);
        return new PuzzleResult(simulatorResult.PixelCount, 121);
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(InputFile);
        return new PuzzleResult(simulatorResult.Letters, "RURUCEOEIL");
    }
}