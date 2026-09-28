using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

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
            if (usable.Count == 0)
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
            var rows = input.Split(LineBreaks.Single);
            _components = rows.Select(ParseComponent).ToList();
        }

        private static BridgeComponent ParseComponent(string s)
        {
            var parts = s.Split('/');
            return new BridgeComponent(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
    
    public record Bridge(int Strength, int Length);
    
    public class BridgeComponent : IEquatable<BridgeComponent>
    {
        public int Port1 { get; }
        public int Port2 { get; }
        public int Strength { get; }
        
        public BridgeComponent(int port1, int port2, int? strength = null)
        {
            Port1 = port1;
            Port2 = port2;
            Strength = strength ?? port1 + port2;
        }

        public bool Equals(BridgeComponent? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Port1 == other.Port1 && Port2 == other.Port2;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BridgeComponent) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Port1, Port2);
        }
    }
}