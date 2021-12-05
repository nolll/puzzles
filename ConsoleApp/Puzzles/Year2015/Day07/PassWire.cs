using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2015.Day07
{
    public class PassWire : Wire
    {
        private readonly IDictionary<string, Wire> _dictionary;
        private readonly string _a;

        private ushort WireASignal => ushort.TryParse(_a, out var n) ? n : _dictionary[_a].Signal;

        public override ushort Signal
        {
            get
            {
                if (_signal == null)
                    _signal = WireASignal;
                return _signal.Value;
            }
        }

        public PassWire(IDictionary<string, Wire> dictionary, string a)
        {
            _dictionary = dictionary;
            _a = a;
        }
    }
}