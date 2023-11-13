using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201507;

public class Aoc201507Tests
{
    [Test]
    public void SignalsAreCorrect()
    {
        const string input = """
123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i
""";

        var circuit = new Circuit(input.Trim());
        circuit.RunOne("i");

        circuit.Wires["d"].Signal.Should().Be(72);
        circuit.Wires["e"].Signal.Should().Be(507);
        circuit.Wires["f"].Signal.Should().Be(492);
        circuit.Wires["g"].Signal.Should().Be(114);
        circuit.Wires["h"].Signal.Should().Be(65412);
        circuit.Wires["i"].Signal.Should().Be(65079);
        circuit.Wires["x"].Signal.Should().Be(123);
        circuit.Wires["y"].Signal.Should().Be(456);
    }
}