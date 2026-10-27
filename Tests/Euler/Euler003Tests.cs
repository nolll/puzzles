using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler003Tests : PuzzleTest<Euler003>
{
    [Fact]
    public void Test() => Sut.Solve(13195).Should().Be(29);
}