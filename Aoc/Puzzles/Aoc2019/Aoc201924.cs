using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Planet of Discord")]
[Comment("Data generation could be cleaned up a little more")]
public class Aoc201924 : AocPuzzle
{
    [Puzzle("1871d15193d508d5be66268ad3cc074a")]
    public long Part1(string input) => RunPart1UntilRepeat(input);

    [Puzzle("4309fbaca8e02ca8066a8fa6b49f9b2b")]
    public int Part2(string input) => RunPart2(input, 200);

    public long RunPart1UntilRepeat(string input)
    {
        var grid = BuildGrid(input);
        var seen = new HashSet<string>();

        while (true)
        {
            grid = NextIteration(grid);
            var print = GridToString(grid);
            if (!seen.Add(print))
                break;
        }

        return BiodiversityRating(grid);
    }

    public string RunPart1(string input, int iterations)
    {
        var grid = BuildGrid(input);

        for (var i = 0; i < iterations; i++)
            grid = NextIteration(grid);

        return GridToString(grid);
    }

    private static Grid<char> NextIteration(Grid<char> grid)
    {
        var newGrid = new Grid<char>(1, 1);
        for (var y = 0; y < grid.Height; y++)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                grid.MoveTo(x, y);
                var currentValue = grid.ReadValue();
                var adjacentValues = grid.OrthogonalAdjacentValues;
                var neighborCount = adjacentValues.Count(o => o == '#');
                var newValue = GetNewValue(currentValue, neighborCount);
                newGrid.MoveTo(x, y);
                newGrid.WriteValue(newValue);
            }
        }

        return newGrid;
    }

    private static string GridToString(Grid<char> grid) => string.Concat(grid.Values);
    
    private static char GetNewValue(char currentValue, int neighborCount) => currentValue switch
    {
        '#' when neighborCount != 1 => '.',
        '.' when neighborCount is 1 or 2 => '#',
        _ => currentValue
    };

    private static long BiodiversityRating(Grid<char> grid)
    {
        long totalScore = 0;
        var currentScore = 1;
        foreach (var c in grid.Values)
        {
            if (c == '#')
                totalScore += currentScore;
            currentScore *= 2;
        }

        return totalScore;
    }

    private static Grid<char> BuildGrid(string map)
    {
        var grid = new Grid<char>();
        var rows = map.Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.ToCharArray();
            foreach (var c in chars)
            {
                grid.WriteValueAt(x, y, c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private const int Size = 5;
    private const int InnerLevel = 1;
    private const int SameLevel = 0;
    private const int OuterLevel = -1;
    private readonly Grid<char> _emptyGrid = new(Size, Size, '.');

    public int RunPart2(string input, int iterations)
    {
        var grids = new Dictionary<int, Grid<char>>
        {
            [-1] = _emptyGrid.Clone(),
            [0] = BuildGrid(input),
            [1] = _emptyGrid.Clone()
        };

        var cells = BuildCells();
        var relativeAddresses = BuildRelativeAddresses(cells);

        for (var i = 0; i < iterations; i++)
        {
            grids = NextIteration(grids, cells, relativeAddresses);
        }

        return BugCount(grids);
    }

    private static int BugCount(Dictionary<int, Grid<char>> grids) => grids.Values.Sum(o => o.Values.Count(m => m == '#'));

    private Grid<char> GetGrid(Dictionary<int, Grid<char>> grids, int level)
    {
        if (grids.TryGetValue(level, out var grid))
            return grid;

        grid = _emptyGrid.Clone();
        grids.Add(level, grid);
        return grid;
    }

    private Dictionary<int, Grid<char>> NextIteration(
        Dictionary<int, Grid<char>> grids,
        Dictionary<int, Coord> cells,
        IDictionary<Coord, IList<RelativeLevelAddress>> relativeAddresses)
    {
        var newGrids = new Dictionary<int, Grid<char>>();
        var levels = grids.Keys.OrderBy(o => o).ToList();
        foreach (var level in levels)
        {
            var grid = GetGrid(grids, level);
            var newGrid = _emptyGrid.Clone();

            foreach (var address in cells.Values)
            {
                var currentValue = grid.ReadValueAt(address);
                var neighborCount = GetNeighborCount(grids, relativeAddresses, level, address);
                var newValue = GetNewValue(currentValue, neighborCount);
                newGrid.MoveTo(address);
                newGrid.WriteValue(newValue);
            }

            newGrids.Add(level, newGrid);
        }

        foreach (var key in grids.Keys)
        {
            if (!newGrids.ContainsKey(key))
                newGrids[key] = _emptyGrid.Clone();
        }

        return newGrids;
    }

    private int GetNeighborCount(
        Dictionary<int, Grid<char>> grids,
        IDictionary<Coord, IList<RelativeLevelAddress>> relativeAddresses,
        int level,
        Coord coord)
    {
        var adjacentValues = GetAdjacentValues(grids, relativeAddresses, level, coord);
        return adjacentValues.Count(o => o == '#');
    }

    private IEnumerable<char> GetAdjacentValues(Dictionary<int, Grid<char>> grids,
        IDictionary<Coord, IList<RelativeLevelAddress>> relativeAddresses, int level, Coord coord)
    {
        var addresses = relativeAddresses[coord];
        foreach (var address in addresses)
        {
            var grid = GetGrid(grids, level + address.RelativeLevel);
            yield return grid.ReadValueAt(address.Address);
        }
    }
    
    private static Dictionary<int, Coord> BuildCells()
    {
        var cells = new Dictionary<int, Coord>();
        var id = 1;
        for (var y = 0; y < 5; y++)
        {
            for (var x = 0; x < 5; x++)
            {
                if (x != 2 || y != 2) 
                    cells.Add(id, new Coord(x, y));
                
                id++;
            }
        }
        
        return cells;
    }

    private IDictionary<Coord, IList<RelativeLevelAddress>> BuildRelativeAddresses(Dictionary<int, Coord> cells) =>
        new Dictionary<Coord, IList<RelativeLevelAddress>>
        {
            [cells[1]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, cells[8]),
                new(SameLevel, cells[2]),
                new(SameLevel, cells[6]),
                new(OuterLevel, cells[12])
            },
            [cells[2]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, cells[8]),
                new(SameLevel, cells[3]),
                new(SameLevel, cells[7]),
                new(SameLevel, cells[1])
            },
            [cells[3]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, cells[8]),
                new(SameLevel, cells[4]),
                new(SameLevel, cells[8]),
                new(SameLevel, cells[2])
            },
            [cells[4]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, cells[8]),
                new(SameLevel, cells[5]),
                new(SameLevel, cells[9]),
                new(SameLevel, cells[3])
            },
            [cells[5]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, cells[8]),
                new(OuterLevel, cells[14]),
                new(SameLevel, cells[10]),
                new(SameLevel, cells[4])
            },
            [cells[6]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[1]),
                new(SameLevel, cells[7]),
                new(SameLevel, cells[11]),
                new(OuterLevel, cells[12])
            },
            [cells[7]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[2]),
                new(SameLevel, cells[8]),
                new(SameLevel, cells[12]),
                new(SameLevel, cells[6])
            },
            [cells[8]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[3]),
                new(SameLevel, cells[9]),
                new(InnerLevel, cells[1]),
                new(InnerLevel, cells[2]),
                new(InnerLevel, cells[3]),
                new(InnerLevel, cells[4]),
                new(InnerLevel, cells[5]),
                new(SameLevel, cells[7])
            },
            [cells[9]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[4]),
                new(SameLevel, cells[10]),
                new(SameLevel, cells[14]),
                new(SameLevel, cells[8])
            },
            [cells[10]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[5]),
                new(OuterLevel, cells[14]),
                new(SameLevel, cells[15]),
                new(SameLevel, cells[9])
            },
            [cells[11]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[6]),
                new(SameLevel, cells[12]),
                new(SameLevel, cells[16]),
                new(OuterLevel, cells[12])
            },
            [cells[12]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[7]),
                new(InnerLevel, cells[1]),
                new(InnerLevel, cells[6]),
                new(InnerLevel, cells[11]),
                new(InnerLevel, cells[16]),
                new(InnerLevel, cells[21]),
                new(SameLevel, cells[17]),
                new(SameLevel, cells[11])
            },
            [cells[14]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[9]),
                new(SameLevel, cells[15]),
                new(SameLevel, cells[19]),
                new(InnerLevel, cells[5]),
                new(InnerLevel, cells[10]),
                new(InnerLevel, cells[15]),
                new(InnerLevel, cells[20]),
                new(InnerLevel, cells[25])
            },
            [cells[15]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[10]),
                new(OuterLevel, cells[14]),
                new(SameLevel, cells[20]),
                new(SameLevel, cells[14])
            },
            [cells[16]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[11]),
                new(SameLevel, cells[17]),
                new(SameLevel, cells[21]),
                new(OuterLevel, cells[12])
            },
            [cells[17]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[12]),
                new(SameLevel, cells[18]),
                new(SameLevel, cells[22]),
                new(SameLevel, cells[16])
            },
            [cells[18]] = new List<RelativeLevelAddress>
            {
                new(InnerLevel, cells[21]),
                new(InnerLevel, cells[22]),
                new(InnerLevel, cells[23]),
                new(InnerLevel, cells[24]),
                new(InnerLevel, cells[25]),
                new(SameLevel, cells[19]),
                new(SameLevel, cells[23]),
                new(SameLevel, cells[17])
            },
            [cells[19]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[14]),
                new(SameLevel, cells[20]),
                new(SameLevel, cells[24]),
                new(SameLevel, cells[18])
            },
            [cells[20]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[15]),
                new(OuterLevel, cells[14]),
                new(SameLevel, cells[25]),
                new(SameLevel, cells[19])
            },
            [cells[21]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[16]),
                new(SameLevel, cells[22]),
                new(OuterLevel, cells[18]),
                new(OuterLevel, cells[12])
            },
            [cells[22]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[17]),
                new(SameLevel, cells[23]),
                new(OuterLevel, cells[18]),
                new(SameLevel, cells[21])
            },
            [cells[23]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[18]),
                new(SameLevel, cells[24]),
                new(OuterLevel, cells[18]),
                new(SameLevel, cells[22])
            },
            [cells[24]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[19]),
                new(SameLevel, cells[25]),
                new(OuterLevel, cells[18]),
                new(SameLevel, cells[23])
            },
            [cells[25]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, cells[20]),
                new(OuterLevel, cells[14]),
                new(OuterLevel, cells[18]),
                new(SameLevel, cells[24])
            }
        };

    public record RelativeLevelAddress(int RelativeLevel, Coord Address);
}