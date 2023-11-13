using FluentAssertions;
using NUnit.Framework;
using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aquaq.Puzzles.Aquaq03;

public class Aquaq03Tests
{
    [TestCase("UDRR", 4, 1, 14)]
    [TestCase("RR", 3, 0, 6)]
    public void ShouldEndAt(string input, int expectedX, int expectedY, int expectedSum)
    {
        var walker = new Walker();
        var result = walker.Walk(input);

        walker.Pos.Should().Be(new MatrixAddress(expectedX, expectedY));
        result.Should().Be(expectedSum);
    }
}