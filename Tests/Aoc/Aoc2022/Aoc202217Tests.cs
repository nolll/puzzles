using Pzl.Aoc.Puzzles.Aoc2022;
using Pzl.Tools.Grids.Grids2d;

namespace Tests.Aoc.Aoc2022;

public class Aoc202217Tests : PuzzleTest<Aoc202217>
{
    private const string Input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(3068);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(1_514_285_714_288);

    [Fact]
    public void CycleFinder_NoCycle()
    {
        var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var result = Sut.FindRepeatCycle(input, 2);
        result.Index.Should().Be(0);
        result.Length.Should().Be(0);
    }

    [Fact]
    public void CycleFinder_CycleFound()
    {
        var input = new[] { 7, 8, 9, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 7 };
        var result = Sut.FindRepeatCycle(input, 2, 11);

        // does not find the start of the sequence, but the first instance of the sequence found
        // the sequence starts at index 3 (value 1) but the search start is returned, index 6 (value 4)
        // the sequence found id 4, 5, 1, 2, 3
        result.Index.Should().Be(6);
        result.Length.Should().Be(5);
    }

    [Fact]
    public void HorizontalLineCanMoveRight()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void HorizontalLineCanNotMoveRight()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(2, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void HorizontalLineCanMoveLeft()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void HorizontalLineCanNotMoveLeft()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(0, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void HorizontalLineCanMoveDown()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 1);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void HorizontalLineCanNotMoveDown()
    {
        var grid = new Grid<char>(6, 3, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new Aoc202217.HorizontalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void PlusCanNotMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(2, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanNotMoveRightBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(3, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void PlusCanNotMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(0, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanNotMoveLeftBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(1, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void PlusCanNotMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void PlusCanNotMoveDownBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(1, 3, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.PlusShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void ReversedLCanMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void ReversedLCanNotMoveRight()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(2, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void ReversedLCanMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void ReversedLCanNotMoveLeft()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(0, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void ReversedLCanNotMoveLeftBlocked()
    {
        var grid = new Grid<char>(5, 5, '.');
        grid.WriteValueAt(2, 1, 'o');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void ReversedLCanMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void ReversedLCanNotMoveDown()
    {
        var grid = new Grid<char>(5, 5, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new Aoc202217.ReversedLShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void SquareCanMoveRight()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void SquareCanNotMoveRight()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(2, 2);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void SquareCanMoveLeft()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void SquareCanNotMoveLeft()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(0, 2);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void SquareCanMoveDown()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 2);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void SquareCanNotMoveDown()
    {
        var grid = new Grid<char>(4, 4, '.');
        var bottomLeft = new Coord(1, 3);
        var shape = new Aoc202217.SquareShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void VerticalLineCanMoveRight()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void VerticalLineCanNotMoveRight()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(2, 4);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveRight(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void VerticalLineCanMoveLeft()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void VerticalLineCanNotMoveLeft()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(0, 4);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveLeft(grid, bottomLeft).Should().BeFalse();
    }

    [Fact]
    public void VerticalLineCanMoveDown()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 4);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeTrue();
    }

    [Fact]
    public void VerticalLineCanNotMoveDown()
    {
        var grid = new Grid<char>(3, 6, '.');
        var bottomLeft = new Coord(1, 5);
        var shape = new Aoc202217.VerticalLineShape();
        shape.Paint(grid, bottomLeft);
        shape.CanMoveDown(grid, bottomLeft).Should().BeFalse();
    }
}