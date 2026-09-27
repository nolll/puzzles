namespace Tests.Euler;

public class Euler001Tests
{
    [Fact]
    public void Test() => new Pzl.Euler.Puzzles.Euler001.Euler001().Solve(10).Should().Be(23);

    private static Pzl.Euler.Puzzles.Euler001.Euler001 Sut => new();
}