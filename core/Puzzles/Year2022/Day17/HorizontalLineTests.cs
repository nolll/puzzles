using System;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day17;

public class HorizontalLineTests
{
    [Test]
    public void CanMoveRight()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        Assert.That(result, Is.True);
    }

    [Test]
    public void CanNotMoveRight()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(2, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        Assert.That(result, Is.False);
    }

    [Test]
    public void CanMoveLeft()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        Assert.That(result, Is.True);
    }

    [Test]
    public void CanNotMoveLeft()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(0, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        Assert.That(result, Is.False);
    }

    [Test]
    public void CanMoveDown()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 1);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        Assert.That(result, Is.True);
    }

    [Test]
    public void CanNotMoveDown()
    {
        var matrix = new QuickDynamicMatrix<char>(6, 3, '.');
        var bottomLeft = new MatrixAddress(1, 2);
        var shape = new HorizontalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        Assert.That(result, Is.False);
    }
}