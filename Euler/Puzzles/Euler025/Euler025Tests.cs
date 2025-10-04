namespace Pzl.Euler.Puzzles.Euler025;

public class Euler025Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler025();
        var result = puzzle.Run(3);

        result.Should().Be(12);
    }
}