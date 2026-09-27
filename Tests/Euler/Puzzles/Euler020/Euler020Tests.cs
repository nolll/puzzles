namespace Tests.Euler.Puzzles.Euler020;

public class Euler020Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler020.Euler020();
        var result = puzzle.Solve(10);

        result.Should().Be(27);
    }
}