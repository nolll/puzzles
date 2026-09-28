using Pzl.Aoc.Puzzles.Aoc2022;
using Pzl.Tools.Grids.Grids2d;

namespace Tests.Aoc.Aoc2022;

public class Aoc202217HorizontalLineTests
{
    [Fact]
    public void CanMoveRight()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(2, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(0, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeFalse();
    }
}