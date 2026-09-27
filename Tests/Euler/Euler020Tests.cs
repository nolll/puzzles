using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler020Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler020();
        var result = puzzle.Solve(10);

        result.Should().Be(27);
    }
}