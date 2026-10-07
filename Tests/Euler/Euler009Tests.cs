using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler009Tests : PuzzleTest<Euler009>
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler009();
        var result = puzzle.Solve(12);

        result.Should().Be(60);
    }
}