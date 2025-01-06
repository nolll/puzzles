using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

public class Matrix3DTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    [Test]
    public void ExtendAllTo3()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        var emptyRowsValue = matrix.ReadValueAt(-1, -1, -1);
        var writtenValue = matrix.ReadValueAt(0, 0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(3);
        matrix.Height.Should().Be(3);
        matrix.Depth.Should().Be(3);
    }

    [Test]
    public void ExtendAll5()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections(2);

        var emptyRowsValue = matrix.ReadValueAt(-1, -1, -1);
        var writtenValue = matrix.ReadValueAt(0, 0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        matrix.Width.Should().Be(5);
        matrix.Height.Should().Be(5);
        matrix.Depth.Should().Be(5);
    }

    [Test]
    public void AllAdjacent6Exists()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.MoveTo(0, 0, 0);

        matrix.OrthogonalAdjacentCoords.Count.Should().Be(6);

        var adjacentCoords = matrix.OrthogonalAdjacentCoords;
        var cubesAtXMin = adjacentCoords.Where(o => o.X == matrix.XMin).ToList();
        var cubesAtYMin = adjacentCoords.Where(o => o.Y == matrix.YMin).ToList();
        var cubesAtZMin = adjacentCoords.Where(o => o.Z == matrix.ZMin).ToList();
        cubesAtXMin.Count.Should().Be(1);
        cubesAtYMin.Count.Should().Be(1);
        cubesAtZMin.Count.Should().Be(1);
    }

    [Test]
    public void AllAdjacent26Exists()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.MoveTo(0, 0, 0);

        matrix.AllAdjacentCoords.Count.Should().Be(26);

        var adjacentCoords = matrix.AllAdjacentCoords;
        var cubesAtXMin = adjacentCoords.Where(o => o.X == matrix.XMin).ToList();
        var cubesAtYMin = adjacentCoords.Where(o => o.Y == matrix.YMin).ToList();
        var cubesAtZMin = adjacentCoords.Where(o => o.Z == matrix.ZMin).ToList();
        cubesAtXMin.Count.Should().Be(9);
        cubesAtYMin.Count.Should().Be(9);
        cubesAtZMin.Count.Should().Be(9);
    }
}