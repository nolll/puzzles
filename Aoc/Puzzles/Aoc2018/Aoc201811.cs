using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Charge")]
public class Aoc201811 : AocPuzzle
{
    private const int DefaultGridSize = 300;

    [Puzzle("f3fc6e4f392f91227d656e153bc6797b")]
    public string Part1(string input) => GetMaxCoords(DefaultGridSize, int.Parse(input)).Id;

    [Puzzle("3519b00562141f570c15da87657755e1")]
    public string Part2(string input)
    {
        var (coords, size) = GetMaxCoordsAnySize(DefaultGridSize, int.Parse(input));
        return $"{coords.Id},{size}";
    }

    private Coord GetMaxCoords(int gridSize, int serialNumber)
    {
        var grid = BuildGrid(gridSize, serialNumber);
        var maxPowerLevel = int.MinValue;
        var maxPowerLevelAddress = new Coord(0, 0);
        for (var y = 0; y < gridSize - 2; y++)
        {
            for (var x = 0; x < gridSize - 2; x++)
            {
                var powerLevel = GetSquarePowerLevel(grid, x, y, 3);
                if (powerLevel > maxPowerLevel)
                {
                    maxPowerLevel = powerLevel;
                    maxPowerLevelAddress = new Coord(x, y);
                }
            }
        }

        return maxPowerLevelAddress;
    }

    private (Coord coords, int size) GetMaxCoordsAnySize(int gridSize, int serialNumber)
    {
        var grid = BuildGrid(gridSize, serialNumber);
        var maxPowerLevel = int.MinValue;
        var maxPowerLevelSize = 0;
        var maxPowerLevelAddress = new Coord(0, 0);
        for (var ySquare = 0; ySquare < gridSize; ySquare++)
        {
            for (var xSquare = 0; xSquare < gridSize; xSquare++)
            {
                var maxSquareSize = gridSize - Math.Max(xSquare, ySquare);
                var powerLevel = 0;
                for (var size = 1; size < maxSquareSize; size++)
                {
                    for (var yy = 0; yy <= size; yy++)
                    {
                        var x = xSquare + size;
                        var y = ySquare + yy;
                        powerLevel += grid[x, y];
                    }

                    for (var xx = 0; xx <= size; xx++)
                    {
                        var x = xSquare + xx;
                        var y = ySquare + size;
                        powerLevel += grid[x, y];
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

    private int[,] BuildGrid(int gridSize, int serialNumber)
    {
        var grid = new int[gridSize, gridSize];
        for (var y = 0; y < gridSize - 2; y++)
        {
            for (var x = 0; x < gridSize - 2; x++)
            {
                var powerLevel = GetSinglePowerLevel(serialNumber, x, y);
                grid[x, y] = powerLevel;
            }
        }

        return grid;
    }

    private static int GetSquarePowerLevel(int[,] grid, int x, int y, int size)
    {
        var total = 0;
        for (var yy = 0; yy < size; yy++)
        {
            for (var xx = 0; xx < size; xx++)
            {
                total += grid[x + xx, y + yy];
            }
        }

        return total;
    }

    public int GetSinglePowerLevel(int serialNumber, int x, int y)
    {
        var rackId = x + 10;
        var i = (rackId * y + serialNumber) * rackId;
        var str = i.ToString();
        return int.Parse(str.Substring(str.Length - 3, 1)) - 5;
    }
}