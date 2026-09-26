namespace Tests.Euler.Puzzles.Euler007;

public class Euler007Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler007.Euler007();
        var result = puzzle.Solve(6);

        result.Should().Be(13);
    }
}