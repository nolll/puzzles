using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler009Tests : PuzzleTest<Euler009>
{
    [Fact]
    public void Test() => Sut.Solve(12).Should().Be(60);
}