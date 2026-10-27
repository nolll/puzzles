using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler001Tests : PuzzleTest<Euler001>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(23);
}