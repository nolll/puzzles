using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler008Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler008();
        var result = puzzle.Solve(4);

        result.Should().Be(5832);
    }
}