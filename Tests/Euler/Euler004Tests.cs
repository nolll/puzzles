using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler004Tests : PuzzleTest<Euler004>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler004();
        var result = puzzle.Solve(10, 99);

        result.Should().Be(9009);
    }
}