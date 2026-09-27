namespace Tests.Euler.Puzzles.Euler022;

public class Euler022Tests
{
    [Fact]
    public void Test() => new Pzl.Euler.Puzzles.Euler022.Euler022.Names().GetScore("COLIN").Should().Be(49714);
}