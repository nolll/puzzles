using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler005Tests : PuzzleTest<Euler005>
{
    [Fact]
    public void Test() => Sut.Solve(10).Should().Be(2520);
}