using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Common.CoordinateSystems.CoordinateSystem4D;

public class Matrix4DTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    [Test]
    public void ExtendAllTo3()
    {
        var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        var emptyRowsValue = matrix.ReadValueAt(0, 0, 0, 0);
        var writtenValue = matrix.ReadValueAt(1, 1, 1, 1);
        matrix.Values.Count.Should().Be(81);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(3);
        matrix.Height.Should().Be(3);
        matrix.Depth.Should().Be(3);
        matrix.Duration.Should().Be(3);
    }

    [Test]
    public void ExtendAll5()
    {
        var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections(2);

        var emptyRowsValue = matrix.ReadValueAt(0, 0, 0, 0);
        var writtenValue = matrix.ReadValueAt(2, 2, 2, 2);
        matrix.Values.Count.Should().Be(625);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(5);
        matrix.Height.Should().Be(5);
        matrix.Depth.Should().Be(5);
        matrix.Duration.Should().Be(5);
    }

    [Test]
    public void AllAdjacentExists()
    {
        var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.MoveTo(1, 1, 1, 1);
            
        matrix.AllAdjacentCoords.Count.Should().Be(80);

        var adjacentCoords = matrix.AllAdjacentCoords;
        var cubesAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
        var cubesAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
        var cubesAtZZero = adjacentCoords.Where(o => o.Z == 0).ToList();
        var cubesAtWZero = adjacentCoords.Where(o => o.W == 0).ToList();
        cubesAtXZero.Count.Should().Be(27);
        cubesAtYZero.Count.Should().Be(27);
        cubesAtZZero.Count.Should().Be(27);
        cubesAtWZero.Count.Should().Be(27);
    }
}