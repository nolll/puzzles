using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler001Tests : PuzzleTest<Euler001>
{
    [Fact]
    public void Test() => new Euler001().Solve(10).Should().Be(23);

}