namespace Tests.Euler.Puzzles.Euler002;

public class Euler002Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler002.Euler002();
        var result = puzzle.Solve(100);

        result.Should().Be(44);
    }
}