using System.Collections.Generic;
using System.Linq;
using Core.CoordinateSystems;

namespace ConsoleApp.Puzzles.Year2019.Day24
{
    public class RecursiveBugLifeSimulator
    {
        private const int Size = 5;
        private const int InnerLevel = 1;
        private const int SameLevel = 0;
        private const int OuterLevel = -1;
        private IDictionary<int, Matrix<char>> _matrixes;
        private readonly IDictionary<MatrixAddress, IList<RelativeLevelAddress>> _relativeAddresses;
        private readonly Dictionary<int, MatrixAddress> _cells;
        private readonly Matrix<char> _emptyMatrix = new Matrix<char>(Size, Size, '.');

        public int BugCount => _matrixes.Values.Sum(o => o.Values.Count(m => m == '#'));

        public RecursiveBugLifeSimulator(string input)
        {
            _matrixes = new Dictionary<int, Matrix<char>>();
            _matrixes[-1] = _emptyMatrix.Copy();
            _matrixes[0] = BuildMatrix(input);
            _matrixes[1] = _emptyMatrix.Copy();

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

        private Matrix<char> GetMatrix(int level)
        {
            if (_matrixes.TryGetValue(level, out var matrix))
                return matrix;

            matrix = _emptyMatrix.Copy();
            _matrixes.Add(level, matrix);
            return matrix;
        }

        private void NextIteration()
        {
            var newMatrixes = new Dictionary<int, Matrix<char>>();
            var levels = _matrixes.Keys.OrderBy(o => o).ToList();
            foreach (var level in levels)
            {
                var matrix = GetMatrix(level);
                var newMatrix = _emptyMatrix.Copy();

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
                    newMatrixes[key] = _emptyMatrix.Copy();
            }

            _matrixes = newMatrixes;
        }

        private int GetNeighborCount(int level, MatrixAddress address)
        {
            var adjacentValues = GetAdjacentValues(level, address);
            return adjacentValues.Count(o => o == '#');
        }

        private IEnumerable<char> GetAdjacentValues(int level, MatrixAddress address)
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

        private Matrix<char> BuildMatrix(string map)
        {
            var matrix = new Matrix<char>(1, 1);
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

        private Dictionary<int, MatrixAddress> BuildCells()
        {
            return new Dictionary<int, MatrixAddress>
            {
                [1] = new MatrixAddress(0, 0),
                [2] = new MatrixAddress(1, 0),
                [3] = new MatrixAddress(2, 0),
                [4] = new MatrixAddress(3, 0),
                [5] = new MatrixAddress(4, 0),
                [6] = new MatrixAddress(0, 1),
                [7] = new MatrixAddress(1, 1),
                [8] = new MatrixAddress(2, 1),
                [9] = new MatrixAddress(3, 1),
                [10] = new MatrixAddress(4, 1),
                [11] = new MatrixAddress(0, 2),
                [12] = new MatrixAddress(1, 2),
                [14] = new MatrixAddress(3, 2),
                [15] = new MatrixAddress(4, 2),
                [16] = new MatrixAddress(0, 3),
                [17] = new MatrixAddress(1, 3),
                [18] = new MatrixAddress(2, 3),
                [19] = new MatrixAddress(3, 3),
                [20] = new MatrixAddress(4, 3),
                [21] = new MatrixAddress(0, 4),
                [22] = new MatrixAddress(1, 4),
                [23] = new MatrixAddress(2, 4),
                [24] = new MatrixAddress(3, 4),
                [25] = new MatrixAddress(4, 4)
            };
        }

        private IDictionary<MatrixAddress, IList<RelativeLevelAddress>> BuildRelativeAddresses()
        {
            var relativeAddresses = new Dictionary<MatrixAddress, IList<RelativeLevelAddress>>
            {
                [_cells[1]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(OuterLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[2]),
                    new RelativeLevelAddress(SameLevel, _cells[6]),
                    new RelativeLevelAddress(OuterLevel, _cells[12])
                },
                [_cells[2]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(OuterLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[3]),
                    new RelativeLevelAddress(SameLevel, _cells[7]),
                    new RelativeLevelAddress(SameLevel, _cells[1])
                },
                [_cells[3]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(OuterLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[4]),
                    new RelativeLevelAddress(SameLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[2])
                },
                [_cells[4]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(OuterLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[5]),
                    new RelativeLevelAddress(SameLevel, _cells[9]),
                    new RelativeLevelAddress(SameLevel, _cells[3])
                },
                [_cells[5]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(OuterLevel, _cells[8]),
                    new RelativeLevelAddress(OuterLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[10]),
                    new RelativeLevelAddress(SameLevel, _cells[4])
                },
                [_cells[6]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[1]),
                    new RelativeLevelAddress(SameLevel, _cells[7]),
                    new RelativeLevelAddress(SameLevel, _cells[11]),
                    new RelativeLevelAddress(OuterLevel, _cells[12])
                },
                [_cells[7]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[2]),
                    new RelativeLevelAddress(SameLevel, _cells[8]),
                    new RelativeLevelAddress(SameLevel, _cells[12]),
                    new RelativeLevelAddress(SameLevel, _cells[6])
                },
                [_cells[8]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[3]),
                    new RelativeLevelAddress(SameLevel, _cells[9]),
                    new RelativeLevelAddress(InnerLevel, _cells[1]),
                    new RelativeLevelAddress(InnerLevel, _cells[2]),
                    new RelativeLevelAddress(InnerLevel, _cells[3]),
                    new RelativeLevelAddress(InnerLevel, _cells[4]),
                    new RelativeLevelAddress(InnerLevel, _cells[5]),
                    new RelativeLevelAddress(SameLevel, _cells[7])
                },
                [_cells[9]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[4]),
                    new RelativeLevelAddress(SameLevel, _cells[10]),
                    new RelativeLevelAddress(SameLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[8])
                },
                [_cells[10]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[5]),
                    new RelativeLevelAddress(OuterLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[15]),
                    new RelativeLevelAddress(SameLevel, _cells[9])
                },
                [_cells[11]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[6]),
                    new RelativeLevelAddress(SameLevel, _cells[12]),
                    new RelativeLevelAddress(SameLevel, _cells[16]),
                    new RelativeLevelAddress(OuterLevel, _cells[12])
                },
                [_cells[12]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[7]),
                    new RelativeLevelAddress(InnerLevel, _cells[1]),
                    new RelativeLevelAddress(InnerLevel, _cells[6]),
                    new RelativeLevelAddress(InnerLevel, _cells[11]),
                    new RelativeLevelAddress(InnerLevel, _cells[16]),
                    new RelativeLevelAddress(InnerLevel, _cells[21]),
                    new RelativeLevelAddress(SameLevel, _cells[17]),
                    new RelativeLevelAddress(SameLevel, _cells[11])
                },
                [_cells[14]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[9]),
                    new RelativeLevelAddress(SameLevel, _cells[15]),
                    new RelativeLevelAddress(SameLevel, _cells[19]),
                    new RelativeLevelAddress(InnerLevel, _cells[5]),
                    new RelativeLevelAddress(InnerLevel, _cells[10]),
                    new RelativeLevelAddress(InnerLevel, _cells[15]),
                    new RelativeLevelAddress(InnerLevel, _cells[20]),
                    new RelativeLevelAddress(InnerLevel, _cells[25])
                },
                [_cells[15]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[10]),
                    new RelativeLevelAddress(OuterLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[20]),
                    new RelativeLevelAddress(SameLevel, _cells[14])
                },
                [_cells[16]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[11]),
                    new RelativeLevelAddress(SameLevel, _cells[17]),
                    new RelativeLevelAddress(SameLevel, _cells[21]),
                    new RelativeLevelAddress(OuterLevel, _cells[12])
                },
                [_cells[17]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[12]),
                    new RelativeLevelAddress(SameLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[22]),
                    new RelativeLevelAddress(SameLevel, _cells[16])
                },
                [_cells[18]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(InnerLevel, _cells[21]),
                    new RelativeLevelAddress(InnerLevel, _cells[22]),
                    new RelativeLevelAddress(InnerLevel, _cells[23]),
                    new RelativeLevelAddress(InnerLevel, _cells[24]),
                    new RelativeLevelAddress(InnerLevel, _cells[25]),
                    new RelativeLevelAddress(SameLevel, _cells[19]),
                    new RelativeLevelAddress(SameLevel, _cells[23]),
                    new RelativeLevelAddress(SameLevel, _cells[17])
                },
                [_cells[19]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[20]),
                    new RelativeLevelAddress(SameLevel, _cells[24]),
                    new RelativeLevelAddress(SameLevel, _cells[18])
                },
                [_cells[20]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[15]),
                    new RelativeLevelAddress(OuterLevel, _cells[14]),
                    new RelativeLevelAddress(SameLevel, _cells[25]),
                    new RelativeLevelAddress(SameLevel, _cells[19])
                },
                [_cells[21]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[16]),
                    new RelativeLevelAddress(SameLevel, _cells[22]),
                    new RelativeLevelAddress(OuterLevel, _cells[18]),
                    new RelativeLevelAddress(OuterLevel, _cells[12])
                },
                [_cells[22]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[17]),
                    new RelativeLevelAddress(SameLevel, _cells[23]),
                    new RelativeLevelAddress(OuterLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[21])
                },
                [_cells[23]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[24]),
                    new RelativeLevelAddress(OuterLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[22])
                },
                [_cells[24]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[19]),
                    new RelativeLevelAddress(SameLevel, _cells[25]),
                    new RelativeLevelAddress(OuterLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[23])
                },
                [_cells[25]] = new List<RelativeLevelAddress>
                {
                    new RelativeLevelAddress(SameLevel, _cells[20]),
                    new RelativeLevelAddress(OuterLevel, _cells[14]),
                    new RelativeLevelAddress(OuterLevel, _cells[18]),
                    new RelativeLevelAddress(SameLevel, _cells[24])
                }
            };

            return relativeAddresses;
        }
    }
}