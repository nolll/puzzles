namespace Pzl.Tools.Grids.Grids2d;

public class GridTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    private const string SliceInput = """
                                      ABCD
                                      EFGH
                                      IJKL
                                      MNOP
                                      """;

    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    public void IsAtTopEdge(int y, bool expected)
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(1, y);

        grid.IsAtTopEdge.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, true)]
    [InlineData(3, false)]
    public void IsAtRightEdge(int x, bool expected)
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(x, 1);

        grid.IsAtRightEdge.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, true)]
    [InlineData(3, false)]
    public void IsAtBottomEdge(int y, bool expected)
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(1, y);

        grid.IsAtBottomEdge.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    public void IsAtLeftEdge(int x, bool expected)
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(x, 1);

        grid.IsAtLeftEdge.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 2)]
    [InlineData(10, 5)]
    public void Center(int size, int expected)
    {
        var grid = new Grid<int>(size, size);

        grid.Center.X.Should().Be(expected);
        grid.Center.Y.Should().Be(expected);
    }

    [Fact]
    public void MoveTo()
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(1, 2);

        grid.Coord.X.Should().Be(1);
        grid.Coord.Y.Should().Be(2);
    }

    [Fact]
    public void MoveForward()
    {
        var grid = new Grid<int>(5, 5);
        grid.MoveTo(1, 3);
        grid.MoveForward();

        grid.Coord.X.Should().Be(1);
        grid.Coord.Y.Should().Be(2);
    }

    [Fact]
    public void TurnAndMoveForward()
    {
        var grid = new Grid<int>(5, 5);
        grid.TurnRight();
        grid.MoveForward();
        grid.TurnRight();
        grid.MoveForward();

        grid.Coord.X.Should().Be(1);
        grid.Coord.Y.Should().Be(1);
    }

    [Fact]
    public void ExtendAllTo3()
    {
        var grid = new Grid<char>(1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        var emptyRowsValue = grid.ReadValueAt(-1, -1);
        var writtenValue = grid.ReadValueAt(0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(3);
        grid.Height.Should().Be(3);
    }

    [Fact]
    public void ExtendAllTo5()
    {
        var grid = new Grid<char>(1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections(2);

        var emptyRowsValue = grid.ReadValueAt(-2, -2);
        var writtenValue = grid.ReadValueAt(0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(5);
        grid.Height.Should().Be(5);
    }

    [Fact]
    public void OrthogonalAdjacentCoordsExist()
    {
        var grid = new Grid<char>(1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        grid.OrthogonalAdjacentCoords.Count.Should().Be(4);

        var adjacentCoords = grid.OrthogonalAdjacentCoords;
        var squaresInFirstCol = adjacentCoords.Where(o => o.X == -1).ToList();
        var squaresInFirstRow = adjacentCoords.Where(o => o.Y == -1).ToList();
        squaresInFirstCol.Count.Should().Be(1);
        squaresInFirstRow.Count.Should().Be(1);
    }

    [Fact]
    public void AllAdjacentCoordsExists()
    {
        var grid = new Grid<char>(1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        grid.AllAdjacentCoords.Count.Should().Be(8);

        var adjacentCoords = grid.AllAdjacentCoords;
        var squaresInFirstCol = adjacentCoords.Where(o => o.X == -1).ToList();
        var squaresInFirstRow = adjacentCoords.Where(o => o.Y == -1).ToList();
        squaresInFirstCol.Count.Should().Be(3);
        squaresInFirstRow.Count.Should().Be(3);
    }

    [Fact]
    public void Clone()
    {
        const string input = """
                             #..
                             #..
                             .#.
                             """;

        const string expected = """
                                #..
                                #..
                                .#.
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Clone();

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void CloneAndMultiply()
    {
        const string input = """
                             #..
                             #..
                             .#.
                             """;

        const string expected = """
                                #..#..
                                #..#..
                                .#..#.
                                #..#..
                                #..#..
                                .#..#.
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Clone(2);

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void RotateRight()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                .##
                                ...
                                ...
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.RotateRight();

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void RotateLeft()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ...
                                ...
                                ##.
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.RotateLeft();

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void Slice()
    {
        const string expected = """
                                FG
                                JK
                                """;

        var grid = GridBuilder.BuildCharGrid(SliceInput);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Slice(new Coord(1, 1), new Coord(2, 2));

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void SliceFrom()
    {
        const string expected = """
                                FGH
                                JKL
                                NOP
                                """;

        var grid = GridBuilder.BuildCharGrid(SliceInput);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Slice(new Coord(1, 1));

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void SliceTo()
    {
        const string expected = """
                                ABC
                                EFG
                                IJK
                                """;

        var grid = GridBuilder.BuildCharGrid(SliceInput);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Slice(to: new Coord(2, 2));

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void SliceSize()
    {
        const string expected = """
                                FG
                                JK
                                """;

        var grid = GridBuilder.BuildCharGrid(SliceInput);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Slice(new Coord(1, 1), 2, 2);

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void FlipVertical()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ...
                                #..
                                #..
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.FlipVertical();

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void FlipHorizontal()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ..#
                                ..#
                                ...
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.FlipHorizontal();

        grid.Print().Should().Be(expectedGrid.Print());
    }

    [Fact]
    public void Transpose()
    {
        const string input = """
                             #..
                             #..
                             ...
                             """;

        const string expected = """
                                ##.
                                ...
                                ...
                                """;

        var grid = GridBuilder.BuildCharGrid(input);
        var expectedGrid = GridBuilder.BuildCharGrid(expected);

        grid = grid.Transpose();

        grid.Print().Should().Be(expectedGrid.Print());
    }
}