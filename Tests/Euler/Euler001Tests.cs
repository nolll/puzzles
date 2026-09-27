using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler001Tests
{
    [Fact]
    public void Test() => new Euler001().Solve(10).Should().Be(23);

    private static Euler001 Sut => new();
}