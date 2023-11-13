using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201811;

public class PowerGrid
{
    private int MatrixSize { get; }
    private readonly int _serialNumber;
    private readonly int[,] _matrix;

    public PowerGrid(int matrixSize, int serialNumber)
    {
        MatrixSize = matrixSize;
        _serialNumber = serialNumber;
        _matrix = new int[MatrixSize, MatrixSize];

        FillMatrix();
    }

    public (MatrixAddress coords, int size) GetMaxCoordsAnySize()
    {
        var maxPowerLevel = int.MinValue;
        var maxPowerLevelSize = 0;
        var maxPowerLevelAddress = new MatrixAddress(0, 0);
        for (var ySquare = 0; ySquare < MatrixSize; ySquare++)
        {
            for (var xSquare = 0; xSquare < MatrixSize; xSquare++)
            {
                var maxSquareSize = MatrixSize - Math.Max(xSquare, ySquare);
                var powerLevel = 0;
                for (var size = 1; size < maxSquareSize; size++)
                {
                    for (var yy = 0; yy <= size; yy++)
                    {
                        var x = xSquare + size;
                        var y = ySquare + yy;
                        powerLevel += _matrix[x, y];
                    }

                    for (var xx = 0; xx <= size; xx++)
                    {
                        var x = xSquare + xx;
                        var y = ySquare + size;
                        powerLevel += _matrix[x, y];
                    }

                    if (powerLevel > maxPowerLevel)
                    {
                        maxPowerLevel = powerLevel;
                        maxPowerLevelSize = size + 1;
                        maxPowerLevelAddress = new MatrixAddress(xSquare, ySquare);
                    }
                }
            }
        }

        return (maxPowerLevelAddress, maxPowerLevelSize);
    }

    private void FillMatrix()
    {
        for (var y = 0; y < MatrixSize - 2; y++)
        {
            for (var x = 0; x < MatrixSize - 2; x++)
            {
                var powerLevel = GetSinglePowerLevel(x, y);
                _matrix[x, y] = powerLevel;
            }
        }
    }

    public MatrixAddress GetMaxCoords()
    {
        var maxPowerLevel = int.MinValue;
        var maxPowerLevelAddress = new MatrixAddress(0, 0);
        for (var y = 0; y < MatrixSize - 2; y++)
        {
            for (var x = 0; x < MatrixSize - 2; x++)
            {
                var powerLevel = GetSquarePowerLevel(x, y, 3);
                if (powerLevel > maxPowerLevel)
                {
                    maxPowerLevel = powerLevel;
                    maxPowerLevelAddress = new MatrixAddress(x, y);
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
                total += _matrix[x + xx, y + yy];
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