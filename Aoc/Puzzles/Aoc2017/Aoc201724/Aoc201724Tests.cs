using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201724;

public class Aoc201724Tests
{
    [Test]
    public void FindsStrongestBridge()
    {
        var builder = new BridgeBuilder(Input.Trim(), false);
        var bridge = builder.Build();

        bridge.Strength.Should().Be(31);
    }

    [Test]
    public void FindsLongestBridge()
    {
        var builder = new BridgeBuilder(Input.Trim(), true);
        var bridge = builder.Build();

        bridge.Strength.Should().Be(19);
    }

    private const string Input = """
                                 0/2
                                 2/2
                                 2/3
                                 3/4
                                 3/5
                                 0/1
                                 10/1
                                 9/10
                                 """;
}