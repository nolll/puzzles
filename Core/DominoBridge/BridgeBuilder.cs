using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DominoBridge
{
    public class BridgeBuilder
    {
        private IList<BridgeComponent> _components;
        private int _cacheHits;
        private int _maxStrength;

        public BridgeBuilder(string input)
        {
            InitComponents(input);
            _cacheHits = 0;
            _maxStrength = 0;
        }

        public int Build()
        {
            var startComponents = _components.Where(o => o.HasZero).OrderByDescending(o => o.Strength).ToList();
            var rootComponent = new BridgeComponent("0/0", 0, 0);
            rootComponent.PossibleConnections = startComponents;
            return BuildBridge(0, rootComponent, _components);
        }

        private int BuildBridge(int previousStrength, BridgeComponent component, IList<BridgeComponent> remainingComponents)
        {
            var subComponents = component.PossibleConnections.Where(remainingComponents.Contains).ToList();
            var remainingStrength = remainingComponents.Sum(o => o.Strength);

            var newStrength = previousStrength + component.Strength;

            if (newStrength + remainingStrength < _maxStrength)
            {
                return 0;
            }
            
            if (newStrength > _maxStrength)
            {
                _maxStrength = newStrength;
            }

            var subStrength = 0;
            foreach (var c in subComponents)
            {
                var s = BuildBridge(newStrength, c, remainingComponents.Where(o => !o.Equals(c)).ToList());
                if (s > subStrength)
                    subStrength = s;
            }

            if (subStrength > 0)
                return subStrength;
            return newStrength;
        }

        private string GetCacheKey(BridgeComponent component, IList<BridgeComponent> remainingComponents)
        {
            var listId = string.Join('-', remainingComponents.Select(o => o.Id));
            return $"{component.Id}:{listId}";
        }

        private void InitComponents(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            _components = rows.Select(ParseComponent).ToList();

            CombineComponents();
            MergeComponents();

        }

        private void CombineComponents()
        {
            foreach (var component in _components)
            {
                component.PossibleConnections = _components
                    .Where(o => !o.HasZero && o.CanConnectTo(component))
                    .ToList();
            }
        }

        private void MergeComponents()
        {
            while (_components.Any(o => o.PossibleConnections.Count <= 2))
            {
                var component = _components.First(o => o.PossibleConnections.Count <= 2);

            }
        }

        private BridgeComponent ParseComponent(string s)
        {
            var parts = s.Split('/');
            return new BridgeComponent(s, int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}