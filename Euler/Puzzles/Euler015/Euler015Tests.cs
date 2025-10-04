namespace Pzl.Euler.Puzzles.Euler015;

public class Euler015Tests
{
    [Theory]
    [InlineData(2, 6)]
    [InlineData(3, 20)]
    [InlineData(4, 70)]
    public void Test(int gridSize, long expected)
    {
        var puzzle = new Euler015();
        var result = puzzle.Run(gridSize);

        result.Should().Be(expected);
    }
}