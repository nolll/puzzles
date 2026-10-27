using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler026Tests : PuzzleTest<Euler026>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(7);
}