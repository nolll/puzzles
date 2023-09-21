using NUnit.Framework;

namespace common.CoordinateSystems.CoordinateSystem3D;

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

        var emptyRowsValue = matrix.ReadValueAt(0, 0, 0);
        var writtenValue = matrix.ReadValueAt(1, 1, 1);
        Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
        Assert.That(writtenValue, Is.EqualTo(WriteValue));
        Assert.That(matrix.Width, Is.EqualTo(3));
        Assert.That(matrix.Height, Is.EqualTo(3));
        Assert.That(matrix.Depth, Is.EqualTo(3));
    }

    [Test]
    public void ExtendAll5()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections(2);

        var emptyRowsValue = matrix.ReadValueAt(0, 0, 0);
        var writtenValue = matrix.ReadValueAt(2, 2, 2);
        Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
        Assert.That(writtenValue, Is.EqualTo(WriteValue));
        Assert.That(matrix.Width, Is.EqualTo(5));
        Assert.That(matrix.Height, Is.EqualTo(5));
        Assert.That(matrix.Depth, Is.EqualTo(5));
    }

    [Test]
    public void AllAdjacent6Exists()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.MoveTo(1, 1, 1);

        Assert.That(matrix.PerpendicularAdjacentCoords.Count, Is.EqualTo(6));

        var adjacentCoords = matrix.PerpendicularAdjacentCoords;
        var cubesAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
        var cubesAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
        var cubesAtZZero = adjacentCoords.Where(o => o.Z == 0).ToList();
        Assert.That(cubesAtXZero.Count, Is.EqualTo(1));
        Assert.That(cubesAtYZero.Count, Is.EqualTo(1));
        Assert.That(cubesAtZZero.Count, Is.EqualTo(1));
    }

    [Test]
    public void AllAdjacent26Exists()
    {
        var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
        matrix.WriteValue(WriteValue);
        matrix.ExtendAllDirections();

        matrix.MoveTo(1, 1, 1);

        Assert.That(matrix.AllAdjacentCoords.Count, Is.EqualTo(26));

        var adjacentCoords = matrix.AllAdjacentCoords;
        var cubesAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
        var cubesAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
        var cubesAtZZero = adjacentCoords.Where(o => o.Z == 0).ToList();
        Assert.That(cubesAtXZero.Count, Is.EqualTo(9));
        Assert.That(cubesAtYZero.Count, Is.EqualTo(9));
        Assert.That(cubesAtZZero.Count, Is.EqualTo(9));
    }
}