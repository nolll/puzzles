using System.Collections.Generic;

namespace App.Puzzles.Year2015.Day07
{
    public class OrWire : Wire
    {
        private readonly IDictionary<string, Wire> _dictionary;
        private readonly string _a;
        private readonly string _b;

        private ushort WireASignal => ushort.TryParse(_a, out var n) ? n : _dictionary[_a].Signal;
        private ushort WireBSignal => ushort.TryParse(_b, out var n) ? n : _dictionary[_b].Signal;

        public override ushort Signal
        {
            get
            {
                if (_signal == null)
                    _signal = (ushort)(WireASignal | WireBSignal);
                return _signal.Value;
            }
        }

        public OrWire(IDictionary<string, Wire> dictionary, string a, string b)
        {
            _dictionary = dictionary;
            _a = a;
            _b = b;
        }
    }
}