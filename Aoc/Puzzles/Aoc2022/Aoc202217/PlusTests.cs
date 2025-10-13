using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class PlusTests
{
    [Fact]
    public void CanMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(2, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveRightBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(3, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveRight(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(0, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveLeftBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(1, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveLeft(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeTrue();
    }

    [Fact]
    public void CanNotMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeFalse();
    }

    [Fact]
    public void CanNotMoveDownBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(1, 3, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new PlusShape();
        shape.Paint(grid, bottomLeft);

        var result = shape.CanMoveDown(grid, bottomLeft);

        result.Should().BeFalse();
    }
}