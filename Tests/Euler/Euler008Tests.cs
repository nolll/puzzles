using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler008Tests : PuzzleTest<Euler008>
{
    [Fact]
    public void Test() => Sut.Solve(4).Should().Be(5832);
}