using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler030Tests : PuzzleTest<Euler030>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler030();
        var result = puzzle.Solve(4);

        result.Should().Be(19316);
    }
}
