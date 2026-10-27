using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler006Tests : PuzzleTest<Euler006>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(2640);
}