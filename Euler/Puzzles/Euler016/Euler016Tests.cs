namespace Pzl.Euler.Puzzles.Euler016;

public class Euler016Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler016();
        var result = puzzle.Run(15);

        result.Should().Be(26);
    }
}