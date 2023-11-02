using Common.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201811;

public class Aoc201811Tests
{
    [TestCase(122, 79, 57, -5)]
    [TestCase(217, 196, 39, 0)]
    [TestCase(101, 153, 71, 4)]
    public void SinglePowerLevelIsCorrect(int x, int y, int serialNumber, int expected)
    {
        var grid = new PowerGrid(300, serialNumber);
        var level = grid.GetSinglePowerLevel(x, y);

        level.Should().Be(expected);
    }

    [TestCase(18, "90,269,16")]
    [TestCase(42, "232,251,12")]
    [Ignore(TestHelper.NCrunchTimeout)]
    public void AnySizePowerLevelIsCorrect(int serialNumber, string expected)
    {
        var grid = new PowerGrid(300, serialNumber);
        var (coords, size) = grid.GetMaxCoordsAnySize();
        var str = $"{coords.X},{coords.Y},{size}";

        str.Should().Be(expected);
    }
}