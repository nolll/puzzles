namespace Pzl.Tools.Grids.Grids3d;

public class Grid3dTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    [Fact]
    public void ExtendAllTo3()
    {
        var grid = new Grid3d<char>(1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        var emptyRowsValue = grid.ReadValueAt(-1, -1, -1);
        var writtenValue = grid.ReadValueAt(0, 0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(3);
        grid.Height.Should().Be(3);
        grid.Depth.Should().Be(3);
    }

    [Fact]
    public void ExtendAll5()
    {
        var grid = new Grid3d<char>(1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections(2);

        var emptyRowsValue = grid.ReadValueAt(-1, -1, -1);
        var writtenValue = grid.ReadValueAt(0, 0, 0);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(5);
        grid.Height.Should().Be(5);
        grid.Depth.Should().Be(5);
    }

    [Fact]
    public void AllAdjacent6Exists()
    {
        var grid = new Grid3d<char>(1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        grid.MoveTo(0, 0, 0);

        grid.OrthogonalAdjacentCoords.Count.Should().Be(6);

        var adjacentCoords = grid.OrthogonalAdjacentCoords;
        var cubesAtXMin = adjacentCoords.Where(o => o.X == grid.XMin).ToList();
        var cubesAtYMin = adjacentCoords.Where(o => o.Y == grid.YMin).ToList();
        var cubesAtZMin = adjacentCoords.Where(o => o.Z == grid.ZMin).ToList();
        cubesAtXMin.Count.Should().Be(1);
        cubesAtYMin.Count.Should().Be(1);
        cubesAtZMin.Count.Should().Be(1);
    }

    [Fact]
    public void AllAdjacent26Exists()
    {
        var grid = new Grid3d<char>(1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        grid.MoveTo(0, 0, 0);

        grid.AllAdjacentCoords.Count.Should().Be(26);

        var adjacentCoords = grid.AllAdjacentCoords;
        var cubesAtXMin = adjacentCoords.Where(o => o.X == grid.XMin).ToList();
        var cubesAtYMin = adjacentCoords.Where(o => o.Y == grid.YMin).ToList();
        var cubesAtZMin = adjacentCoords.Where(o => o.Z == grid.ZMin).ToList();
        cubesAtXMin.Count.Should().Be(9);
        cubesAtYMin.Count.Should().Be(9);
        cubesAtZMin.Count.Should().Be(9);
    }
}