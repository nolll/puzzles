using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler012Tests : PuzzleTest<Euler012>
{
    [Fact]
    public void Test() => Sut.Solve(5).Should().Be(28);
}