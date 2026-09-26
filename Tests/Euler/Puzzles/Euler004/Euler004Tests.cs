namespace Tests.Euler.Puzzles.Euler004;

public class Euler004Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler004.Euler004();
        var result = puzzle.Solve(10, 99);

        result.Should().Be(9009);
    }
}