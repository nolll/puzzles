using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler007Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler007();
        var result = puzzle.Solve(6);

        result.Should().Be(13);
    }
}