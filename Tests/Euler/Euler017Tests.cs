using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler017Tests : PuzzleTest<Euler017>
{
    [Fact]
    public void Test() => Sut.Solve(5).Should().Be(19);
}