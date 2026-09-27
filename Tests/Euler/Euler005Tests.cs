using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler005Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler005();
        var result = puzzle.Solve(10);

        result.Should().Be(2520);
    }
}