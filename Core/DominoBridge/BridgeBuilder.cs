using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DominoBridge
{
    public class BridgeBuilder
    {
        private IList<BridgeComponent> _components;

        public BridgeBuilder(string input)
        {
            InitComponents(input);
        }

        public int Build()
        {
            return BuildBridge(0, 0, _components);
        }

        private int BuildBridge(int strength, int port, IList<BridgeComponent> availableComponents)
        {
            var usable = availableComponents.Where(o => o.Port1 == port || o.Port2 == port).ToList();
            if (!usable.Any())
                return strength;

            var strengths = new List<int>();
            foreach (var c in usable)
            {
                var remainingComponents = availableComponents.ToList();
                remainingComponents.Remove(c);
                var nextStrength = strength + c.Strength;
                var nextPort = port == c.Port1 ? c.Port2 : c.Port1;
                var s = BuildBridge(nextStrength, nextPort, remainingComponents);
                strengths.Add(s);
            }

            return strengths.Max();
        }

        private void InitComponents(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            _components = rows.Select(ParseComponent).ToList();
        }

        private BridgeComponent ParseComponent(string s)
        {
            var parts = s.Split('/');
            return new BridgeComponent(s, int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}