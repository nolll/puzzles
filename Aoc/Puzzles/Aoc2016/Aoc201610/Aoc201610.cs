using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201610;

[Name("Balance Bots")]
public class Aoc201610(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var simulator = new BotSimulator(input);
        var botId = simulator.FindIdByChips(17, 61);
        return new PuzzleResult(botId, "5141409a7397bcdc4bb364bbb1ea2965");
    }

    protected override PuzzleResult RunPart2()
    {
        var simulator = new BotSimulator(input);
        var multipliedOutput = simulator.GetMultipliedOutput();
        return new PuzzleResult(multipliedOutput, "1e81841d2042e89e46105118a32aee33");
    }
}