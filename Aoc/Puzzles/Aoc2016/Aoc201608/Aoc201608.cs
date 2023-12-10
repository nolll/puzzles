using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201608;

[Name("Two-Factor Authentication")]
public class Aoc201608 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(InputFile);
        return new PuzzleResult(simulatorResult.PixelCount, "40e526702a7945ea86fbcec32dd72a4d");
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new ScreenSimulator(50, 6);
        var simulatorResult = simulator.Run(InputFile);
        return new PuzzleResult(simulatorResult.Letters, "5eb2504556c7376b34258205d7ef40f2");
    }
}