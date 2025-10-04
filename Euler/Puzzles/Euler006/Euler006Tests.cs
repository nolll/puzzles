namespace Pzl.Euler.Puzzles.Euler006;

public class Euler006Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler006();
        var result = puzzle.Run(10);

        result.Should().Be(2640);
    }
}