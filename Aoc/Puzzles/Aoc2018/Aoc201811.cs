using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Charge")]
public class Aoc201811 : AocPuzzle
{
    [Puzzle("f3fc6e4f392f91227d656e153bc6797b")]
    public string Part1(string input) => new PowerGrid(300, int.Parse(input)).GetMaxCoords().Id;

    [Puzzle("3519b00562141f570c15da87657755e1")]
    public string Part2(string input)
    {
        var grid = new PowerGrid(300, int.Parse(input));
        var (coords, size) = grid.GetMaxCoordsAnySize();
        return $"{coords.Id},{size}";
    }

    public class PowerGrid
    {
        private int GridSize { get; }
        private readonly int _serialNumber;
        private readonly int[,] _grid;

        public PowerGrid(int gridSize, int serialNumber)
        {
            GridSize = gridSize;
            _serialNumber = serialNumber;
            _grid = new int[GridSize, GridSize];

            FillGrid();
        }

        public (Coord coords, int size) GetMaxCoordsAnySize()
        {
            var maxPowerLevel = int.MinValue;
            var maxPowerLevelSize = 0;
            var maxPowerLevelAddress = new Coord(0, 0);
            for (var ySquare = 0; ySquare < GridSize; ySquare++)
            {
                for (var xSquare = 0; xSquare < GridSize; xSquare++)
                {
                    var maxSquareSize = GridSize - Math.Max(xSquare, ySquare);
                    var powerLevel = 0;
                    for (var size = 1; size < maxSquareSize; size++)
                    {
                        for (var yy = 0; yy <= size; yy++)
                        {
                            var x = xSquare + size;
                            var y = ySquare + yy;
                            powerLevel += _grid[x, y];
                        }

                        for (var xx = 0; xx <= size; xx++)
                        {
                            var x = xSquare + xx;
                            var y = ySquare + size;
                            powerLevel += _grid[x, y];
                        }

                        if (powerLevel > maxPowerLevel)
                        {
                            maxPowerLevel = powerLevel;
                            maxPowerLevelSize = size + 1;
                            maxPowerLevelAddress = new Coord(xSquare, ySquare);
                        }
                    }
                }
            }

            return (maxPowerLevelAddress, maxPowerLevelSize);
        }

        private void FillGrid()
        {
            for (var y = 0; y < GridSize - 2; y++)
            {
                for (var x = 0; x < GridSize - 2; x++)
                {
                    var powerLevel = GetSinglePowerLevel(x, y);
                    _grid[x, y] = powerLevel;
                }
            }
        }

        public Coord GetMaxCoords()
        {
            var maxPowerLevel = int.MinValue;
            var maxPowerLevelAddress = new Coord(0, 0);
            for (var y = 0; y < GridSize - 2; y++)
            {
                for (var x = 0; x < GridSize - 2; x++)
                {
                    var powerLevel = GetSquarePowerLevel(x, y, 3);
                    if (powerLevel > maxPowerLevel)
                    {
                        maxPowerLevel = powerLevel;
                        maxPowerLevelAddress = new Coord(x, y);
                    }
                }
            }

            return maxPowerLevelAddress;
        }

        private int GetSquarePowerLevel(int x, int y, int size)
        {
            var total = 0;
            for (var yy = 0; yy < size; yy++)
            {
                for (var xx = 0; xx < size; xx++)
                {
                    total += _grid[x + xx, y + yy];
                }
            }

            return total;
        }

        public int GetSinglePowerLevel(int x, int y)
        {
            var rackId = x + 10;
            var i = (rackId * y + _serialNumber) * rackId;
            var str = i.ToString();
            return int.Parse(str.Substring(str.Length - 3, 1)) - 5;
        }
    }
}