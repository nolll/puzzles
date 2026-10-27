using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler007Tests : PuzzleTest<Euler007>
{
    [Fact]
    public void Test() => Sut.Solve(6).Should().Be(13);
}