using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201724;

public class BridgeBuilder
{
    private readonly bool _findLongestBridge;
    private IList<BridgeComponent> _components = new List<BridgeComponent>();

    public BridgeBuilder(string input, bool findLongestBridge)
    {
        _findLongestBridge = findLongestBridge;
        InitComponents(input);
    }

    public Bridge Build()
    {
        return BuildBridge(new Bridge(0, 0), 0, _components);
    }

    private Bridge BuildBridge(Bridge bridge, int port, IList<BridgeComponent> availableComponents)
    {
        var usable = availableComponents.Where(o => o.Port1 == port || o.Port2 == port).ToList();
        if (!usable.Any())
            return bridge;

        var bridges = new List<Bridge>();
        foreach (var c in usable)
        {
            var remainingComponents = availableComponents.ToList();
            remainingComponents.Remove(c);
            var newBridge = new Bridge(bridge.Strength + c.Strength, bridge.Length + 1);
            var nextPort = port == c.Port1 ? c.Port2 : c.Port1;
            bridges.Add(BuildBridge(newBridge, nextPort, remainingComponents));
        }

        return _findLongestBridge
            ? bridges.OrderBy(o => o.Length).ThenBy(o => o.Strength).Last()
            : bridges.OrderBy(o => o.Strength).Last();
    }

    private void InitComponents(string input)
    {
        var rows = StringReader.ReadLines(input);
        _components = rows.Select(ParseComponent).ToList();
    }

    private BridgeComponent ParseComponent(string s)
    {
        var parts = s.Split('/');
        return new BridgeComponent(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}