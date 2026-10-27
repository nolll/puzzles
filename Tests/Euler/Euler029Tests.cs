using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler029Tests : PuzzleTest<Euler029>
{
    [Fact]
    public void Test() => Sut.Solve(5).Should().Be(15);
}