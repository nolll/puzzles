using System;
using Common.CoordinateSystems.CoordinateSystem2D;
using NUnit.Framework;

namespace Aoc.Puzzles.Year2022.Day17;

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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
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

        Assert.That(result, Is.True);
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

        Assert.That(result, Is.False);
    }
}