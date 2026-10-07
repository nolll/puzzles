using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler016Tests : PuzzleTest<Euler016>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler016();
        var result = puzzle.Solve(15);

        result.Should().Be(26);
    }
}