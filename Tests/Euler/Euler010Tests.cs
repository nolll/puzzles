using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler010Tests : PuzzleTest<Euler010>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler010();
        var result = puzzle.Solve(10);

        result.Should().Be(17);
    }
}