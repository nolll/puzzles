using System;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day17;

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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
    }
}