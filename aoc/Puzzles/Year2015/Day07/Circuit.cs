using System.Collections.Generic;
using Common.Strings;

namespace Aoc.Puzzles.Year2015.Day07;

public class Circuit
{
    private readonly string _input;
    public IDictionary<string, Wire> Wires { get; private set; } = new Dictionary<string, Wire>();

    public Circuit(string input)
    {
        _input = input;
    }

    public ushort RunOne(string key)
    {
        Wires = GetWires(_input);
        return Wires[key].Signal;
    }

    public ushort RunTwo(string readKey, string writeKey)
    {
        var result1 = RunOne(readKey);
        Wires = GetWires(_input);
        Wires[writeKey].SetSignal(result1);
        return Wires[readKey].Signal;
    }

    private IDictionary<string, Wire> GetWires(string input)
    {
        var strings = PuzzleInputReader.ReadLines(input);
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
                {
                    wires.Add(name, new AndWire(wires, a, b));

                }

                else if (command == "OR")
                {
                    wires.Add(name, new OrWire(wires, a, b));
                }

                else if (command == "LSHIFT")
                {
                    wires.Add(name, new LeftShiftWire(wires, a, ushort.Parse(b)));
                }

                else if (command == "RSHIFT")
                {
                    wires.Add(name, new RightShiftWire(wires, a, ushort.Parse(b)));
                }
            }
        }

        return wires;
    }
}