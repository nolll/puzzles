using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler028Tests : PuzzleTest<Euler028>
{
    [Fact]
    public void Test() => Sut.Solve(5).Should().Be(101);
}