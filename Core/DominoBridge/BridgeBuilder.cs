using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DominoBridge
{
    public class BridgeBuilder
    {
        private readonly IList<BridgeComponent> _components;

        public BridgeBuilder(string input)
        {
            _components = ParseComponents(input);
        }

        public int Build()
        {
            var startComponents = _components.Where(o => o.IsStartComponent).ToList();
            var rootComponent = new BridgeComponent(0, 0);
            rootComponent.PossibleConnections = startComponents;
            return BuildBridge(rootComponent, _components);
        }

        private int BuildBridge(BridgeComponent component, IList<BridgeComponent> remainingComponents)
        {
            var subStrength = 0;
            foreach (var c in component.PossibleConnections.Where(remainingComponents.Contains))
            {
                var s = BuildBridge(c, remainingComponents.Where(o => !o.Equals(c)).ToList());
                if (s > subStrength)
                    subStrength = s;
            }

            return component.Strength + subStrength;
        }

        private IList<BridgeComponent> ParseComponents(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            var components = rows.Select(ParseComponent).ToList();

            foreach (var component in components)
            {
                component.PossibleConnections = components
                    .Where(o => !o.IsStartComponent && o.CanConnectTo(component))
                    .ToList();
            }

            return components;
        }

        private BridgeComponent ParseComponent(string s)
        {
            var parts = s.Split('/');
            return new BridgeComponent(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}