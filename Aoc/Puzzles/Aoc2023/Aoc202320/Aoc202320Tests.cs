using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202320;

public class Aoc202320Tests
{
    [Test]
    public void CountPulsesExample1()
    {
        const string input = """
                             broadcaster -> a, b, c
                             %a -> b
                             %b -> c
                             %c -> inv
                             &inv -> a
                             """;

        var result = Aoc202320.CountPulses(input, 1000);

        result.Should().Be(32000000);
    }
    
    [Test]
    public void CountPulsesExample2()
    {
        const string input = """
                             broadcaster -> a
                             %a -> inv, con
                             &inv -> b
                             %b -> con
                             &con -> output
                             """;

        var result = Aoc202320.CountPulses(input, 1000);

        result.Should().Be(11687500);
    }
}