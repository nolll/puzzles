using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Electromagnetic Moat")]
public class Aoc201724 : AocPuzzle
{
    [Puzzle("3f5f426fb50c5a81ce933bb8643b77e5")]
    public int Part1(string input) => Run(input, false);

    [Puzzle("1a92832b066895c2eb684e67960aef58")]
    public int Part2(string input) => Run(input, true);

    private static int Run(string input, bool findLongestBridge)
    {
        var rows = input.Split(LineBreaks.Single);
        var components = rows.Select(ParseComponent).ToList();
        var bridge = BuildBridge(new Bridge(0, 0), 0, components, findLongestBridge);
        return bridge.Strength;
    }

    private static Bridge BuildBridge(Bridge bridge, int port, IList<BridgeComponent> availableComponents, bool findLongestBridge)
    {
        var usable = availableComponents.Where(o => o.Port1 == port || o.Port2 == port).ToList();
        if (usable.Count == 0)
            return bridge;

        var bridges = new List<Bridge>();
        foreach (var c in usable)
        {
            var remainingComponents = availableComponents.ToList();
            remainingComponents.Remove(c);
            var newBridge = new Bridge(bridge.Strength + c.Strength, bridge.Length + 1);
            var nextPort = port == c.Port1 ? c.Port2 : c.Port1;
            bridges.Add(BuildBridge(newBridge, nextPort, remainingComponents, findLongestBridge));
        }

        return findLongestBridge
            ? bridges.OrderBy(o => o.Length).ThenBy(o => o.Strength).Last()
            : bridges.OrderBy(o => o.Strength).Last();
    }

    private static BridgeComponent ParseComponent(string s)
    {
        var (p1, p2) = s.Split('/');
        return new BridgeComponent(int.Parse(p1), int.Parse(p2));
    }

    private record Bridge(int Strength, int Length);

    private record BridgeComponent(int Port1, int Port2)
    {
        public readonly int Strength = Port1 + Port2;
    }
}