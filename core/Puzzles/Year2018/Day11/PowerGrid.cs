using System;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2018.Day11;

public class PowerGrid
{
    private int MatrixSize { get; }
    private readonly int _serialNumber;
    private readonly Matrix<int> _matrix;

    public PowerGrid(int matrixSize, int serialNumber)
    {
        MatrixSize = matrixSize;
        _serialNumber = serialNumber;
        _matrix = new Matrix<int>(MatrixSize, MatrixSize);

        FillMatrix();
    }

    public void Print()
    {
        Console.WriteLine(_matrix.Print());
    }

    public (MatrixAddress coords, int size) GetMaxCoordsAnySizeSlow()
    {
        var maxPowerLevel = int.MinValue;
        var maxPowerLevelSize = 0;
        var maxPowerLevelAddress = new MatrixAddress(0, 0);
        for (var y = 0; y < MatrixSize; y++)
        {
            for (var x = 0; x < MatrixSize; x++)
            {
                _matrix.MoveTo(x, y);
                var maxSquareSize = MatrixSize - Math.Max(x, y);
                for (var size = 1; size < maxSquareSize; size++)
                {
                    var powerLevel = GetSquarePowerLevel(x, y, size);
                    Console.WriteLine(powerLevel);

                    if (powerLevel > maxPowerLevel)
                    {
                        maxPowerLevel = powerLevel;
                        maxPowerLevelSize = size;
                        maxPowerLevelAddress = new MatrixAddress(_matrix.Address.X, _matrix.Address.Y);
                    }
                }
            }
        }

        return (maxPowerLevelAddress, maxPowerLevelSize);
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
                _matrix.MoveTo(xSquare, ySquare);
                var maxSquareSize = MatrixSize - Math.Max(xSquare, ySquare);
                var powerLevel = 0;
                for (var size = 1; size < maxSquareSize; size++)
                {
                    if (size == 1)
                    {
                        powerLevel += _matrix.ReadValueAt(0, 0);
                    }
                    else
                    {
                        for (var yy = 0; yy <= size; yy++)
                        {
                            var x = xSquare + size;
                            var y = ySquare + yy;
                            powerLevel += _matrix.ReadValueAt(x, y);
                        }
                        for (var xx = 0; xx < size; xx++)
                        {
                            var x = xSquare + xx;
                            var y = ySquare + size;
                            powerLevel += _matrix.ReadValueAt(x, y);
                        }
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
                _matrix.MoveTo(x, y);
                _matrix.WriteValue(powerLevel);
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
                _matrix.MoveTo(x, y);
                var powerLevel = GetSquarePowerLevel(x, y, 3);
                if (powerLevel > maxPowerLevel)
                {
                    maxPowerLevel = powerLevel;
                    maxPowerLevelAddress = new MatrixAddress(_matrix.Address.X, _matrix.Address.Y);
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
                total += _matrix.ReadValueAt(x + xx, y + yy);
            }
        }

        return total;
    }

    public int GetSinglePowerLevel(int x, int y)
    {
        var rackId = x + 10;
        var i = (rackId * y + _serialNumber) * rackId;
        var str = i.ToString();
        var c = str.Substring(str.Length - 3, 1);
        return int.Parse(str.Substring(str.Length - 3, 1)) - 5;
    }
}