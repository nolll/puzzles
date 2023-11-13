using FluentAssertions;
using NUnit.Framework;
using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202217;

public class VerticalLineTests
{
    [Test]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(2, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(0, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(3, 6, '.');
        var bottomLeft = new MatrixAddress(1, 5);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}