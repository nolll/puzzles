using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201507;

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

        Assert.That(circuit.Wires["d"].Signal, Is.EqualTo(72));
        Assert.That(circuit.Wires["e"].Signal, Is.EqualTo(507));
        Assert.That(circuit.Wires["f"].Signal, Is.EqualTo(492));
        Assert.That(circuit.Wires["g"].Signal, Is.EqualTo(114));
        Assert.That(circuit.Wires["h"].Signal, Is.EqualTo(65412));
        Assert.That(circuit.Wires["i"].Signal, Is.EqualTo(65079));
        Assert.That(circuit.Wires["x"].Signal, Is.EqualTo(123));
        Assert.That(circuit.Wires["y"].Signal, Is.EqualTo(456));
    }
}