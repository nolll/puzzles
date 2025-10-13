namespace Pzl.Tools.Grids.Grids4d;

public class Grid4dTests
{
    private const char DefaultValue = '.';
    private const char WriteValue = '#';

    [Fact]
    public void ExtendAllTo3()
    {
        var grid = new Grid4d<char>(1, 1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        var emptyRowsValue = grid.ReadValueAt(0, 0, 0, 0);
        var writtenValue = grid.ReadValueAt(1, 1, 1, 1);
        grid.Values.Count.Should().Be(81);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(3);
        grid.Height.Should().Be(3);
        grid.Depth.Should().Be(3);
        grid.Duration.Should().Be(3);
    }

    [Fact]
    public void ExtendAll5()
    {
        var grid = new Grid4d<char>(1, 1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections(2);

        var emptyRowsValue = grid.ReadValueAt(0, 0, 0, 0);
        var writtenValue = grid.ReadValueAt(2, 2, 2, 2);
        grid.Values.Count.Should().Be(625);
        emptyRowsValue.Should().Be(DefaultValue);
        writtenValue.Should().Be(WriteValue);
        grid.Width.Should().Be(5);
        grid.Height.Should().Be(5);
        grid.Depth.Should().Be(5);
        grid.Duration.Should().Be(5);
    }

    [Fact]
    public void AllAdjacentExists()
    {
        var grid = new Grid4d<char>(1, 1, 1, 1, DefaultValue);
        grid.WriteValue(WriteValue);
        grid.ExtendAllDirections();

        grid.MoveTo(1, 1, 1, 1);
            
        grid.AllAdjacentCoords.Count.Should().Be(80);

        var adjacentCoords = grid.AllAdjacentCoords;
        var cubesAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
        var cubesAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
        var cubesAtZZero = adjacentCoords.Where(o => o.Z == 0).ToList();
        var cubesAtWZero = adjacentCoords.Where(o => o.W == 0).ToList();
        cubesAtXZero.Count.Should().Be(27);
        cubesAtYZero.Count.Should().Be(27);
        cubesAtZZero.Count.Should().Be(27);
        cubesAtWZero.Count.Should().Be(27);
    }
}