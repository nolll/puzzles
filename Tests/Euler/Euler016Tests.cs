using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler016Tests : PuzzleTest<Euler016>
{
    [Fact]
    public void Test() => Sut.Solve(15).Should().Be(26);
}