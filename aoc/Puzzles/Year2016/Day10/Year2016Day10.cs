using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day10;

public class Year2016Day10 : AocPuzzle
{
    public override string Name => "Balance Bots";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new BotSimulator(FileInput);
        var botId = simulator.FindIdByChips(17, 61);
        return new PuzzleResult(botId, 118);
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new BotSimulator(FileInput);
        var multipliedOutput = simulator.GetMultipliedOutput();
        return new PuzzleResult(multipliedOutput, 143153);
    }
}