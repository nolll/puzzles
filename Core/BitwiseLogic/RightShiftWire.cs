using System.Collections.Generic;

namespace Core.BitwiseLogic
{
    public class RightShiftWire : Wire
    {
        private ushort? _signal;
        private readonly IDictionary<string, Wire> _dictionary;
        private readonly string _a;
        private readonly ushort _distance;

        private ushort WireASignal => _dictionary[_a].Signal;
        
        public override ushort Signal
        {
            get
            {
                if (_signal == null)
                    _signal = (ushort)(WireASignal >> _distance);
                return _signal.Value;
            }
        }

        public RightShiftWire(IDictionary<string, Wire> dictionary, string a, ushort distance)
        {
            _dictionary = dictionary;
            _a = a;
            _distance = distance;
        }
    }
}