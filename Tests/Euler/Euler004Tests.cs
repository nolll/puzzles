using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler004Tests : PuzzleTest<Euler004>
{
    [Fact]
    public void Test() => Sut.Solve(10, 99).Should().Be(9009);
}