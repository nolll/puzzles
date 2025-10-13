using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class VerticalLineTests
{
    [Fact]
    public void CanMoveRight()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(2, 4);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(0, 4);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 5);
        var shape = new VerticalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeFalse();
    }
}