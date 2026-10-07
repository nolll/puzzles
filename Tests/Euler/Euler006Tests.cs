using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler006Tests : PuzzleTest<Euler006>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler006();
        var result = puzzle.Solve(10);

        result.Should().Be(2640);
    }
}