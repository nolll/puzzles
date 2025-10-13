using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

public class SeaMonsterCounter
{
    private const string SeaMonsterPattern = """
                                             ..................#.
                                             #....##....##....###
                                             .#..#..#..#..#..#...
                                             """;

    private readonly List<Func<Grid<char>, Grid<char>>> _searchFlips = new()
    {
        matrix => matrix.FlipVertical(),
        matrix => matrix.FlipHorizontal(),
        matrix => matrix.FlipVertical(),
        matrix => matrix.FlipHorizontal()
    };

    private readonly Grid<char> _seaMonsterGrid;
    private readonly List<Coord> _seaMonsterHashAddresses;

    public SeaMonsterCounter()
    {
        _seaMonsterGrid = GridBuilder.BuildCharGrid(SeaMonsterPattern);
        _seaMonsterHashAddresses = _seaMonsterGrid.Coords.Where(o => _seaMonsterGrid.ReadValueAt(o) == '#').ToList();
    }

    private int Count(Grid<char> grid)
    {
        var seaMonsterCount = 0;
        for (var y = 0; y < grid.Height - _seaMonsterGrid.Height; y++)
        {
            for (var x = 0; x < grid.Width - _seaMonsterGrid.Width; x++)
            {
                var foundSeaMonster = _seaMonsterHashAddresses.All(address => grid.ReadValueAt(x + address.X, y + address.Y) == '#');
                seaMonsterCount += foundSeaMonster ? 1 : 0;
            }
        }

        return seaMonsterCount;
    }

    public int GetCount(Grid<char> grid)
    {
        foreach (var flip in _searchFlips)
        {
            grid = flip(grid);
            for (var i = 0; i < 4; i++)
            {
                grid = grid.RotateRight();

                var count = Count(grid);
                if (count > 0)
                    return count;
            }
        }

        return 0;
    }
}