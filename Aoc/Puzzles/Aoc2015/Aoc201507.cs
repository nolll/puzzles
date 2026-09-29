using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Some Assembly Required")]
public class Aoc201507 : AocPuzzle
{
    [Puzzle("d726fcd2e75525a2fa0a5c741cc7582f")]
    public int Part1(string input) => RunOne(input)["a"].Signal;

    [Puzzle("135c8ac6a573e214fabaf9728fc2cddb")]
    public int Part2(string input) => RunTwo(input, "a", "b")["a"].Signal;

    public IDictionary<string, Wire> RunOne(string input) => GetWires(input);

    public IDictionary<string, Wire> RunTwo(string input, string readKey, string writeKey)
    {
        var result1 = RunOne(input)[readKey].Signal;
        var wires = GetWires(input);
        wires[writeKey].SetSignal(result1);
        return wires;
    }

    private static IDictionary<string, Wire> GetWires(string input)
    {
        var strings = input.Split(LineBreaks.Single);
        var wires = new Dictionary<string, Wire>();
        foreach (var s in strings)
        {
            var commandAndName = s.Split("->");
            var commandAndValues = commandAndName[0].Trim().Split(' ');
            var name = commandAndName[1].Trim();

            if (commandAndValues.Length == 1)
            {
                var a = commandAndValues[0].Trim();
                wires.Add(name, new PassWire(wires, a));
            }
            else if (commandAndValues.Length == 2)
            {
                var source = commandAndValues[1].Trim();
                wires.Add(name, new NotWire(wires, source));
            }
            else if (commandAndValues.Length == 3)
            {
                var a = commandAndValues[0].Trim();
                var command = commandAndValues[1].Trim();
                var b = commandAndValues[2].Trim();

                if (command == "AND")
                    wires.Add(name, new AndWire(wires, a, b));
                else if (command == "OR")
                    wires.Add(name, new OrWire(wires, a, b));
                else if (command == "LSHIFT")
                    wires.Add(name, new LeftShiftWire(wires, a, ushort.Parse(b)));
                else if (command == "RSHIFT")
                    wires.Add(name, new RightShiftWire(wires, a, ushort.Parse(b)));
            }
        }

        return wires;
    }

    public abstract class Wire
    {
        protected ushort? InternalSignal;

        public abstract ushort Signal { get; }

        public void SetSignal(ushort signal)
        {
            InternalSignal = signal;
        }
    }

    public class AndWire(IDictionary<string, Wire> dictionary, string a, string b) : Wire
    {
        private ushort WireASignal => ushort.TryParse(a, out var n) ? n : dictionary[a].Signal;
        private ushort WireBSignal => ushort.TryParse(b, out var n) ? n : dictionary[b].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= (ushort)(WireASignal & WireBSignal);
                return InternalSignal.Value;
            }
        }
    }

    public class LeftShiftWire(IDictionary<string, Wire> dictionary, string a, ushort distance)
        : Wire
    {
        private ushort WireASignal => dictionary[a].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= (ushort)(WireASignal << distance);
                return InternalSignal.Value;
            }
        }
    }

    public class NotWire(IDictionary<string, Wire> dictionary, string a) : Wire
    {
        private ushort WireASignal => dictionary[a].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= (ushort)~WireASignal;
                return InternalSignal.Value;
            }
        }
    }

    public class OrWire(IDictionary<string, Wire> dictionary, string a, string b) : Wire
    {
        private ushort WireASignal => ushort.TryParse(a, out var n) ? n : dictionary[a].Signal;
        private ushort WireBSignal => ushort.TryParse(b, out var n) ? n : dictionary[b].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= (ushort)(WireASignal | WireBSignal);
                return InternalSignal.Value;
            }
        }
    }

    public class PassWire(IDictionary<string, Wire> dictionary, string a) : Wire
    {
        private ushort WireASignal => ushort.TryParse(a, out var n) ? n : dictionary[a].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= WireASignal;
                return InternalSignal.Value;
            }
        }
    }

    public class RightShiftWire(IDictionary<string, Wire> dictionary, string a, ushort distance)
        : Wire
    {
        private ushort WireASignal => dictionary[a].Signal;

        public override ushort Signal
        {
            get
            {
                InternalSignal ??= (ushort)(WireASignal >> distance);
                return InternalSignal.Value;
            }
        }
    }
}