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
            var startComponents = _components.Where(o => o.HasZero).ToList();
            var rootComponent = new BridgeComponent("0/0", 0, 0);
            rootComponent.PossibleConnections = startComponents;
            return BuildBridge(rootComponent, _components);
        }

        private int BuildBridge(BridgeComponent component, IList<BridgeComponent> remainingComponents)
        {
            var subStrength = 0;
            var connections = component.PossibleConnections.Where(remainingComponents.Contains).ToList();
            foreach (var c in connections)
            {
                var s = BuildBridge(c, remainingComponents.Where(o => !o.Equals(c)).ToList());
                if (s > subStrength)
                    subStrength = s;
            }

            return component.Strength + subStrength;
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

            MergeComponents();

            foreach (var component in _components)
            {
                component.PossibleConnections = _components
                    .Where(o => !o.HasZero && o.CanConnectTo(component))
                    .ToList();
            }
        }

        private void MergeComponents()
        {
            while (true)
            {
                var component = _components.FirstOrDefault(IsContained);
                if (component == null)
                    break;

                var connections = GetConnections(component);
                var connection1 = connections.First();
                var connection2 = connections.Last();
                var strength = component.Strength + connection1.Strength + connection2.Strength;

                if (component.IsDouble)
                {
                    var portToRemove = component.Port1;
                    var port1 = connection1.Port1 == portToRemove ? connection1.Port2 : connection1.Port1;
                    var port2 = connection2.Port1 == portToRemove ? connection2.Port2 : connection2.Port1;
                    var newComponent = new BridgeComponent($"{port1}/{port2}", port1, port2, strength);
                    _components.Remove(component);
                   
                    _components.Add(newComponent);
                }
                else
                {
                    var port1ToRemove = component.Port1;
                    var port2ToRemove = component.Port2;
                    var port1 = connection1.Port1 == port1ToRemove || connection1.Port1 == port2ToRemove ? connection1.Port2 : connection1.Port1;
                    var port2 = connection2.Port1 == port1ToRemove || connection2.Port1 == port2ToRemove ? connection2.Port2 : connection2.Port1;
                    var newComponent = new BridgeComponent($"{port1}/{port2}", port1, port2, strength);
                    _components.Remove(component);
                    _components.Add(newComponent);
                }
                _components.Remove(connection1);
                _components.Remove(connection2);
            }
        }

        private bool IsContained(BridgeComponent component)
        {
            var connections = GetConnections(component);
            return !component.HasZero && (IsDoubleWithTwoConnections(component, connections) || HasOneConnectionPerPort(component, connections));
        }

        private bool HasOneConnectionPerPort(BridgeComponent component, IList<BridgeComponent> connections)
        {
            return connections.Count == 2 && ConnectionCountPort1(component, connections) == 1 && ConnectionCountPort2(component, connections) == 1;
        }

        private bool IsDoubleWithTwoConnections(BridgeComponent component, IList<BridgeComponent> connections)
        {
            return component.IsDouble && connections.Count == 2;
        }

        private int ConnectionCountPort1(BridgeComponent component, IList<BridgeComponent> connections)
        {
            return connections.Count(o => o.CanConnectToPort(component.Port1));
        }

        private int ConnectionCountPort2(BridgeComponent component, IList<BridgeComponent> connections)
        {
            return connections.Count(o => o.CanConnectToPort(component.Port2));
        }

        private IList<BridgeComponent> GetConnections(BridgeComponent component)
        {
            return _components.Where(o => o.CanConnectTo(component)).ToList();
        }

        private BridgeComponent ParseComponent(string s)
        {
            var parts = s.Split('/');
            return new BridgeComponent(s, int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}