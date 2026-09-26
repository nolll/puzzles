namespace Tests.Euler.Puzzles.Euler005;

public class Euler005Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler005.Euler005();
        var result = puzzle.Solve(10);

        result.Should().Be(2520);
    }
}