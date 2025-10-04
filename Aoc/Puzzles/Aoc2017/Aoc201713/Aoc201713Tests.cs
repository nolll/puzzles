namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201713;

public class Aoc201713Tests
{
    [Fact]
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
     
    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(1, 0, false)]
    [InlineData(2, 0, true)]
    [InlineData(2, 1, false)]
    [InlineData(2, 2, true)]
    [InlineData(3, 2, false)]
    [InlineData(3, 3, false)]
    [InlineData(3, 4, true)]
    public void IsCaughtAfterIterations(int range, int iteration, bool expected)
    {
        var layer = new FirewallLayer(range);
        var pos = layer.IsCaught(iteration);

        pos.Should().Be(expected);
    }

    [Fact]
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