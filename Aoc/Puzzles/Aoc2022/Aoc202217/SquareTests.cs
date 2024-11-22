using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class SquareTests
{
    [Test]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(2, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(0, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new MatrixAddress(1, 3);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}