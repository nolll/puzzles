using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler028Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler028();
        var result = puzzle.Solve(5);

        result.Should().Be(101);
    }
}