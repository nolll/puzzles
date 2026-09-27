using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler029Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler029();
        var result = puzzle.Solve(5);

        result.Should().Be(15);
    }
}