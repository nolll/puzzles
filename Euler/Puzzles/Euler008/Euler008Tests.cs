namespace Pzl.Euler.Puzzles.Euler008;

public class Euler008Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler008();
        var result = puzzle.Run(4);

        result.Should().Be(5832);
    }
}