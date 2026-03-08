using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201724;

[Name("Electromagnetic Moat")]
public class Aoc201724 : AocPuzzle
{
    [Puzzle("3f5f426fb50c5a81ce933bb8643b77e5")]
    public int Part1(string input)
    {
        var builder1 = new BridgeBuilder(input, false);
        var bridge1 = builder1.Build();
        return bridge1.Strength;
    }

    [Puzzle("1a92832b066895c2eb684e67960aef58")]
    public int Part2(string input)
    {
        var builder2 = new BridgeBuilder(input, true);
        var bridge2 = builder2.Build();
        return bridge2.Strength;
    }
}