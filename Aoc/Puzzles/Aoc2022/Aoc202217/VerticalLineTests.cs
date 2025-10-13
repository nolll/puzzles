using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class VerticalLineTests
{
    [Fact]
    public void CanMoveRight()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(2, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveRight(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(0, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveLeft(matrix, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var matrix = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 5);
        var shape = new VerticalLineShape();
        shape.Paint(matrix, bottomLeft);
        Console.WriteLine(matrix.Print());

        var result = shape.CanMoveDown(matrix, bottomLeft);

        result.Should().BeFalse();
    }
}