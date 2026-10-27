using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler020Tests : PuzzleTest<Euler020>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(27);
}