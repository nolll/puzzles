using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler022Tests
{
    [Fact]
    public void Test() => new Euler022.Names().GetScore("COLIN").Should().Be(49714);
}