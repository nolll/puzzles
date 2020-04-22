using System;

namespace Core.DominoBridge
{
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