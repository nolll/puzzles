using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler017Tests : PuzzleTest<Euler017>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler017();
        var result = puzzle.Solve(5);

        result.Should().Be(19);
    }
}