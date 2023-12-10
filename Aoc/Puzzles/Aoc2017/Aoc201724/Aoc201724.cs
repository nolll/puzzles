using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201724;

[Name("Electromagnetic Moat")]
public class Aoc201724 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var builder1 = new BridgeBuilder(InputFile, false);
        var bridge1 = builder1.Build();
        return new PuzzleResult(bridge1.Strength, "3f5f426fb50c5a81ce933bb8643b77e5");
    }

    protected override PuzzleResult RunPart2()
    {
        var builder2 = new BridgeBuilder(InputFile, true);
        var bridge2 = builder2.Build();
        return new PuzzleResult(bridge2.Strength, "1a92832b066895c2eb684e67960aef58");
    }
}