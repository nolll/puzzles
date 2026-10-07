using Pzl.Aquaq.Puzzles;
using Pzl.Tools.Grids.Grids2d;

namespace Tests.Aquaq;

public class Aquaq03Tests : PuzzleTest<Aquaq03>
{
    [Theory]
    [InlineData("UDRR", 4, 1, 14)]
    [InlineData("RR", 3, 0, 6)]
    public void ShouldEndAt(string input, int expectedX, int expectedY, int expectedSum)
    {
        var walker = new Aquaq03.Walker();
        var result = walker.Walk(input);

        walker.Pos.Should().Be(new Coord(expectedX, expectedY));
        result.Should().Be(expectedSum);
    }
}