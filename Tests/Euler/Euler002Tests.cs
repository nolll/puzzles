using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler002Tests : PuzzleTest<Euler002>
{
    [Fact]
    public void Test() => Sut.Solve(100).Should().Be(44);
}