namespace Tests.Euler;

public class Euler008Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler008.Euler008();
        var result = puzzle.Solve(4);

        result.Should().Be(5832);
    }
}