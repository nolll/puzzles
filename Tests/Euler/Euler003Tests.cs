using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler003Tests : PuzzleTest<Euler003>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler003();
        var result = puzzle.Solve(13195);

        result.Should().Be(29);
    }
}