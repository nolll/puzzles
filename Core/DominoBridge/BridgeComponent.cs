using System;
using System.Collections.Generic;

namespace Core.DominoBridge
{
    public class BridgeComponent : IEquatable<BridgeComponent>
    {
        public string Id { get; }
        public int Port1 { get; }
        public int Port2 { get; }
        public int Strength { get; }
        public bool IsDouble { get; }
        public bool HasZero { get; }
        public IList<BridgeComponent> PossibleConnections { get; set; }

        public BridgeComponent(string id, int port1, int port2, int? strength = null)
        {
            Id = id;
            Port1 = port1;
            Port2 = port2;
            Strength = strength ?? port1 + port2;
            IsDouble = port1 == port2;
            HasZero = port1 == 0 || port2 == 0;
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

        public bool CanConnectToPort(int port)
        {
            return Port1 == port || Port2 == port;
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