using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201713;

public class Aoc201713Tests
{
    [Test]
    public void SeverityIsCorrect()
    {
        const string input = """
0: 3
1: 2
4: 4
6: 4
""";

        var scanner = new PacketScanner(input.Trim());
        var severity = scanner.GetSeverity();
        severity.Should().Be(24);
    }
        
    [TestCase(0, 0, false)]
    [TestCase(1, 0, false)]

    [TestCase(2, 0, true)]
    [TestCase(2, 1, false)]
    [TestCase(2, 2, true)]

    [TestCase(3, 2, false)]
    [TestCase(3, 3, false)]
    [TestCase(3, 4, true)]
    public void IsCaughtAfterIterations(int range, int iteration, bool expected)
    {
        var layer = new FirewallLayer(range);
        var pos = layer.IsCaught(iteration);

        pos.Should().Be(expected);
    }

    [Test]
    public void DelayUntilPassIsCorrect()
    {
        const string input = """
0: 3
1: 2
4: 4
6: 4
""";

        var scanner = new PacketScanner(input.Trim());
        var delay = scanner.DelayUntilPass();
        delay.Should().Be(10);
    }
}