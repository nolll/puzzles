using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class Circuit(string input)
{
    public IDictionary<string, Wire> Wires { get; private set; } = new Dictionary<string, Wire>();

    public ushort RunOne(string key)
    {
        Wires = GetWires(input);
        return Wires[key].Signal;
    }

    public ushort RunTwo(string readKey, string writeKey)
    {
        var result1 = RunOne(readKey);
        Wires = GetWires(input);
        Wires[writeKey].SetSignal(result1);
        return Wires[readKey].Signal;
    }

    private IDictionary<string, Wire> GetWires(string input)
    {
        var strings = StringReader.ReadLines(input);
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
}