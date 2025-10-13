using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class PlusTests
{
    [Fact]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(2, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveRightBlocked()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        matrix.WriteValueAt(3, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(0, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveLeftBlocked()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        matrix.WriteValueAt(1, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveDownBlocked()
    {
        var matrix = new Matrix<char>(5, 5, '.');
        matrix.WriteValueAt(1, 3, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}