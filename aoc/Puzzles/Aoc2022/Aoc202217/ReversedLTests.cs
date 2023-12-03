using FluentAssertions;
using NUnit.Framework;
using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202217;

public class ReversedLTests
{
    [Test]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(1, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(2, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }
    
    [Test]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(1, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(0, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanNotMoveLeftBlocked()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        matrix.WriteValueAt(2, 1, 'o');
        var bottomLeft = new MatrixAddress(1, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Test]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(1, 3);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Test]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new MatrixAddress(1, 4);
        var shape = new ReversedLShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}