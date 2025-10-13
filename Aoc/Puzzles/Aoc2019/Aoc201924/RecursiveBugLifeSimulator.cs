using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class RecursiveBugLifeSimulator
{
    private const int Size = 5;
    private const int InnerLevel = 1;
    private const int SameLevel = 0;
    private const int OuterLevel = -1;
    private IDictionary<int, Grid<char>> _matrixes;
    private readonly IDictionary<Coord, IList<RelativeLevelAddress>> _relativeAddresses;
    private readonly Dictionary<int, Coord> _cells;
    private readonly Grid<char> _emptyGrid = new Grid<char>(Size, Size, '.');

    public int BugCount => _matrixes.Values.Sum(o => o.Values.Count(m => m == '#'));

    public RecursiveBugLifeSimulator(string input)
    {
        _matrixes = new Dictionary<int, Grid<char>>();
        _matrixes[-1] = _emptyGrid.Clone();
        _matrixes[0] = BuildMatrix(input);
        _matrixes[1] = _emptyGrid.Clone();

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

    private Grid<char> GetMatrix(int level)
    {
        if (_matrixes.TryGetValue(level, out var matrix))
            return matrix;

        matrix = _emptyGrid.Clone();
        _matrixes.Add(level, matrix);
        return matrix;
    }

    private void NextIteration()
    {
        var newMatrixes = new Dictionary<int, Grid<char>>();
        var levels = _matrixes.Keys.OrderBy(o => o).ToList();
        foreach (var level in levels)
        {
            var matrix = GetMatrix(level);
            var newMatrix = _emptyGrid.Clone();

            foreach (var address in _cells.Values)
            {
                var currentValue = matrix.ReadValueAt(address);
                var neighborCount = GetNeighborCount(level, address);
                var newValue = GetNewValue(currentValue, neighborCount);
                newMatrix.MoveTo(address);
                newMatrix.WriteValue(newValue);
            }

            newMatrixes.Add(level, newMatrix);
        }

        foreach (var key in _matrixes.Keys)
        {
            if (!newMatrixes.ContainsKey(key))
                newMatrixes[key] = _emptyGrid.Clone();
        }

        _matrixes = newMatrixes;
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
            var matrix = GetMatrix(level + relativeLevelAddress.RelativeLevel);
            yield return matrix.ReadValueAt(relativeLevelAddress.Address);
        }
    }

    private char GetNewValue(char currentValue, int neighborCount)
    {
        if (currentValue == '#' && neighborCount != 1)
            return '.';

        if (currentValue == '.' && (neighborCount == 1 || neighborCount == 2))
            return '#';

        return currentValue;
    }

    private static Grid<char> BuildMatrix(string map)
    {
        var matrix = new Grid<char>(1, 1);
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }

    private static Dictionary<int, Coord> BuildCells()
    {
        return new Dictionary<int, Coord>
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
    }

    private IDictionary<Coord, IList<RelativeLevelAddress>> BuildRelativeAddresses()
    {
        var relativeAddresses = new Dictionary<Coord, IList<RelativeLevelAddress>>
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

        return relativeAddresses;
    }
}