using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class SquareTests
{
    [Fact]
    public void CanMoveRight()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(2, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(0, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var matrix = new Matrix<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new SquareShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}