namespace Tests.Euler.Puzzles.Euler017;

public class Euler017Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler017.Euler017();
        var result = puzzle.Solve(5);

        result.Should().Be(19);
    }
}