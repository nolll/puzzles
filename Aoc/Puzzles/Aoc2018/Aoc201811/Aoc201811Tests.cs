using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201811;

public class Aoc201811Tests
{
    [Theory]
    [InlineData(122, 79, 57, -5)]
    [InlineData(217, 196, 39, 0)]
    [InlineData(101, 153, 71, 4)]
    public void SinglePowerLevelIsCorrect(int x, int y, int serialNumber, int expected)
    {
        var grid = new PowerGrid(300, serialNumber);
        var level = grid.GetSinglePowerLevel(x, y);

        level.Should().Be(expected);
    }

    [Theory(Skip = TestHelper.NCrunchTimeout)]
    [InlineData(18, "90,269,16")]
    [InlineData(42, "232,251,12")]
    public void AnySizePowerLevelIsCorrect(int serialNumber, string expected)
    {
        var grid = new PowerGrid(300, serialNumber);
        var (coords, size) = grid.GetMaxCoordsAnySize();
        var str = $"{coords.X},{coords.Y},{size}";

        str.Should().Be(expected);
    }
}