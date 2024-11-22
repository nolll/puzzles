using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class HorizontalLineTests
{
    [Test]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(2, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(0, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 2);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}