using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class RecursiveBugLifeSimulator
{
    private const int Size = 5;
    private const int InnerLevel = 1;
    private const int SameLevel = 0;
    private const int OuterLevel = -1;
    private IDictionary<int, Grid<char>> _grids;
    private readonly IDictionary<Coord, IList<RelativeLevelAddress>> _relativeAddresses;
    private readonly Dictionary<int, Coord> _cells;
    private readonly Grid<char> _emptyGrid = new(Size, Size, '.');

    public int BugCount => _grids.Values.Sum(o => o.Values.Count(m => m == '#'));

    public RecursiveBugLifeSimulator(string input)
    {
        _grids = new Dictionary<int, Grid<char>>();
        _grids[-1] = _emptyGrid.Clone();
        _grids[0] = BuildGrid(input);
        _grids[1] = _emptyGrid.Clone();

        _cells = BuildCells();
        _relativeAddresses = BuildRelativeAddresses();
    }

    public void Run(int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            NextIteration();
        }
    }

    private Grid<char> GetGrid(int level)
    {
        if (_grids.TryGetValue(level, out var grid))
            return grid;

        grid = _emptyGrid.Clone();
        _grids.Add(level, grid);
        return grid;
    }

    private void NextIteration()
    {
        var newGrids = new Dictionary<int, Grid<char>>();
        var levels = _grids.Keys.OrderBy(o => o).ToList();
        foreach (var level in levels)
        {
            var grid = GetGrid(level);
            var newGrid = _emptyGrid.Clone();

            foreach (var address in _cells.Values)
            {
                var currentValue = grid.ReadValueAt(address);
                var neighborCount = GetNeighborCount(level, address);
                var newValue = GetNewValue(currentValue, neighborCount);
                newGrid.MoveTo(address);
                newGrid.WriteValue(newValue);
            }

            newGrids.Add(level, newGrid);
        }

        foreach (var key in _grids.Keys)
        {
            if (!newGrids.ContainsKey(key))
                newGrids[key] = _emptyGrid.Clone();
        }

        _grids = newGrids;
    }

    private int GetNeighborCount(int level, Coord address)
    {
        var adjacentValues = GetAdjacentValues(level, address);
        return adjacentValues.Count(o => o == '#');
    }

    private IEnumerable<char> GetAdjacentValues(int level, Coord address)
    {
        var adjacentAddresses = _relativeAddresses[address];
        foreach (var relativeLevelAddress in adjacentAddresses)
        {
            var grid = GetGrid(level + relativeLevelAddress.RelativeLevel);
            yield return grid.ReadValueAt(relativeLevelAddress.Address);
        }
    }

    private static char GetNewValue(char currentValue, int neighborCount) => currentValue switch
    {
        '#' when neighborCount != 1 => '.',
        '.' when neighborCount is 1 or 2 => '#',
        _ => currentValue
    };

    private static Grid<char> BuildGrid(string map)
    {
        var grid = new Grid<char>(1, 1);
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private static Dictionary<int, Coord> BuildCells() => new()
    {
        [1] = new(0, 0),
        [2] = new(1, 0),
        [3] = new(2, 0),
        [4] = new(3, 0),
        [5] = new(4, 0),
        [6] = new(0, 1),
        [7] = new(1, 1),
        [8] = new(2, 1),
        [9] = new(3, 1),
        [10] = new(4, 1),
        [11] = new(0, 2),
        [12] = new(1, 2),
        [14] = new(3, 2),
        [15] = new(4, 2),
        [16] = new(0, 3),
        [17] = new(1, 3),
        [18] = new(2, 3),
        [19] = new(3, 3),
        [20] = new(4, 3),
        [21] = new(0, 4),
        [22] = new(1, 4),
        [23] = new(2, 4),
        [24] = new(3, 4),
        [25] = new(4, 4)
    };

    private IDictionary<Coord, IList<RelativeLevelAddress>> BuildRelativeAddresses() =>
        new Dictionary<Coord, IList<RelativeLevelAddress>>
        {
            [_cells[1]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, _cells[8]),
                new(SameLevel, _cells[2]),
                new(SameLevel, _cells[6]),
                new(OuterLevel, _cells[12])
            },
            [_cells[2]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, _cells[8]),
                new(SameLevel, _cells[3]),
                new(SameLevel, _cells[7]),
                new(SameLevel, _cells[1])
            },
            [_cells[3]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, _cells[8]),
                new(SameLevel, _cells[4]),
                new(SameLevel, _cells[8]),
                new(SameLevel, _cells[2])
            },
            [_cells[4]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, _cells[8]),
                new(SameLevel, _cells[5]),
                new(SameLevel, _cells[9]),
                new(SameLevel, _cells[3])
            },
            [_cells[5]] = new List<RelativeLevelAddress>
            {
                new(OuterLevel, _cells[8]),
                new(OuterLevel, _cells[14]),
                new(SameLevel, _cells[10]),
                new(SameLevel, _cells[4])
            },
            [_cells[6]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[1]),
                new(SameLevel, _cells[7]),
                new(SameLevel, _cells[11]),
                new(OuterLevel, _cells[12])
            },
            [_cells[7]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[2]),
                new(SameLevel, _cells[8]),
                new(SameLevel, _cells[12]),
                new(SameLevel, _cells[6])
            },
            [_cells[8]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[3]),
                new(SameLevel, _cells[9]),
                new(InnerLevel, _cells[1]),
                new(InnerLevel, _cells[2]),
                new(InnerLevel, _cells[3]),
                new(InnerLevel, _cells[4]),
                new(InnerLevel, _cells[5]),
                new(SameLevel, _cells[7])
            },
            [_cells[9]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[4]),
                new(SameLevel, _cells[10]),
                new(SameLevel, _cells[14]),
                new(SameLevel, _cells[8])
            },
            [_cells[10]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[5]),
                new(OuterLevel, _cells[14]),
                new(SameLevel, _cells[15]),
                new(SameLevel, _cells[9])
            },
            [_cells[11]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[6]),
                new(SameLevel, _cells[12]),
                new(SameLevel, _cells[16]),
                new(OuterLevel, _cells[12])
            },
            [_cells[12]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[7]),
                new(InnerLevel, _cells[1]),
                new(InnerLevel, _cells[6]),
                new(InnerLevel, _cells[11]),
                new(InnerLevel, _cells[16]),
                new(InnerLevel, _cells[21]),
                new(SameLevel, _cells[17]),
                new(SameLevel, _cells[11])
            },
            [_cells[14]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[9]),
                new(SameLevel, _cells[15]),
                new(SameLevel, _cells[19]),
                new(InnerLevel, _cells[5]),
                new(InnerLevel, _cells[10]),
                new(InnerLevel, _cells[15]),
                new(InnerLevel, _cells[20]),
                new(InnerLevel, _cells[25])
            },
            [_cells[15]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[10]),
                new(OuterLevel, _cells[14]),
                new(SameLevel, _cells[20]),
                new(SameLevel, _cells[14])
            },
            [_cells[16]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[11]),
                new(SameLevel, _cells[17]),
                new(SameLevel, _cells[21]),
                new(OuterLevel, _cells[12])
            },
            [_cells[17]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[12]),
                new(SameLevel, _cells[18]),
                new(SameLevel, _cells[22]),
                new(SameLevel, _cells[16])
            },
            [_cells[18]] = new List<RelativeLevelAddress>
            {
                new(InnerLevel, _cells[21]),
                new(InnerLevel, _cells[22]),
                new(InnerLevel, _cells[23]),
                new(InnerLevel, _cells[24]),
                new(InnerLevel, _cells[25]),
                new(SameLevel, _cells[19]),
                new(SameLevel, _cells[23]),
                new(SameLevel, _cells[17])
            },
            [_cells[19]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[14]),
                new(SameLevel, _cells[20]),
                new(SameLevel, _cells[24]),
                new(SameLevel, _cells[18])
            },
            [_cells[20]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[15]),
                new(OuterLevel, _cells[14]),
                new(SameLevel, _cells[25]),
                new(SameLevel, _cells[19])
            },
            [_cells[21]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[16]),
                new(SameLevel, _cells[22]),
                new(OuterLevel, _cells[18]),
                new(OuterLevel, _cells[12])
            },
            [_cells[22]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[17]),
                new(SameLevel, _cells[23]),
                new(OuterLevel, _cells[18]),
                new(SameLevel, _cells[21])
            },
            [_cells[23]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[18]),
                new(SameLevel, _cells[24]),
                new(OuterLevel, _cells[18]),
                new(SameLevel, _cells[22])
            },
            [_cells[24]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[19]),
                new(SameLevel, _cells[25]),
                new(OuterLevel, _cells[18]),
                new(SameLevel, _cells[23])
            },
            [_cells[25]] = new List<RelativeLevelAddress>
            {
                new(SameLevel, _cells[20]),
                new(OuterLevel, _cells[14]),
                new(OuterLevel, _cells[18]),
                new(SameLevel, _cells[24])
            }
        };
}