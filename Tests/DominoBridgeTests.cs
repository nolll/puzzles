using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class DominoBridgeTests
    {
        [Test]
        public void FindsStrongestBridge()
        {
            const string input = @"
0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

            var builder = new BridgeBuilder(input);
            var bridgeStrength = builder.Build();

            Assert.That(bridgeStrength, Is.EqualTo(31));
        }
    }

    public class BridgeBuilder
    {
        public BridgeBuilder(string input)
        {
            var components = ParseComponents(input);
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

        public int Build()
        {
            return 0;
        }
    }

    public class BridgeComponent : IEquatable<BridgeComponent>
    {
        public int Port1 { get; }
        public int Port2 { get; }
        public bool IsStartComponent { get; }
        public IList<BridgeComponent> PossibleConnections { get; set; }

        public BridgeComponent(int port1, int port2)
        {
            Port1 = port1;
            Port2 = port2;
            IsStartComponent = port1 == 0 || port2 == 0;
        }

        public bool CanConnectTo(BridgeComponent other)
        {
            return !Equals(other) &&
                   (
                       Port1 == other.Port1 ||
                       Port2 == other.Port1 ||
                       Port1 == other.Port2 ||
                       Port2 == other.Port2
                   );
        }

        public bool Equals(BridgeComponent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Port1 == other.Port1 && Port2 == other.Port2;
        }

        public override bool Equals(object obj)
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