using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler010Tests : PuzzleTest<Euler010>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(17);
}