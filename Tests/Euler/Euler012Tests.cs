using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler012Tests : PuzzleTest<Euler012>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler012();
        var result = puzzle.Solve(5);

        result.Should().Be(28);
    }
}