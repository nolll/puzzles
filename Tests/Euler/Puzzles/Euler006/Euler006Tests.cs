namespace Tests.Euler.Puzzles.Euler006;

public class Euler006Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler006.Euler006();
        var result = puzzle.Solve(10);

        result.Should().Be(2640);
    }
}