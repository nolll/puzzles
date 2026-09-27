namespace Tests.Euler.Puzzles.Euler016;

public class Euler016Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler016.Euler016();
        var result = puzzle.Solve(15);

        result.Should().Be(26);
    }
}