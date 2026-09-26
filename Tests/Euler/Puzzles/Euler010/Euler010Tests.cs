namespace Tests.Euler.Puzzles.Euler010;

public class Euler010Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler010.Euler010();
        var result = puzzle.Solve(10);

        result.Should().Be(17);
    }
}