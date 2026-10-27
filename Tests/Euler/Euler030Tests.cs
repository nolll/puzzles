using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler030Tests : PuzzleTest<Euler030>
{
    [Fact]
    public void Test() => Sut.Solve(4).Should().Be(19316);
}
