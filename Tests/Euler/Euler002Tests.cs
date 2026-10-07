using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler002Tests : PuzzleTest<Euler002>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler002();
        var result = puzzle.Solve(100);

        result.Should().Be(44);
    }
}