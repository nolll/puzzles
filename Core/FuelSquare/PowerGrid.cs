using System;
using System.Drawing;
using Core.Tools;

namespace Core.FuelSquare
{
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

        public (MatrixAddress coords, int size) GetMaxCoordsAnySizeSlow()
        {
            var maxPowerLevel = int.MinValue;
            var maxPowerLevelSize = 0;
            var maxPowerLevelAddress = new MatrixAddress(0, 0);
            for (var y = 0; y < MatrixSize; y++)
            {
                Console.WriteLine(y);
                for (var x = 0; x < MatrixSize; x++)
                {
                    _matrix.MoveTo(x, y);
                    var maxSquareSize = MatrixSize - Math.Max(x, y);
                    for (var size = 1; size < maxSquareSize; size++)
                    {
                        var powerLevel = GetSquarePowerLevel(x, y, size);
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

        public (MatrixAddress coords, int size) GetMaxCoordsAnySizeFast()
        {
            var maxPowerLevel = int.MinValue;
            var maxPowerLevelSize = 0;
            var maxPowerLevelAddress = new MatrixAddress(0, 0);
            for (var y = 0; y < MatrixSize; y++)
            {
                Console.WriteLine(y);
                for (var x = 0; x < MatrixSize; x++)
                {
                    _matrix.MoveTo(x, y);
                    var maxSquareSize = MatrixSize - Math.Max(x, y);
                    for (var size = 0; size < maxSquareSize; size++)
                    {
                        var powerLevel = _matrix.ReadValueAt(x, y);
                        for (var yy = 0; yy < size; yy++)
                        {
                            powerLevel += _matrix.ReadValueAt(x, y + yy);
                        }
                        for (var xx = 0; xx < size - 1; xx++)
                        {
                            powerLevel += _matrix.ReadValueAt(x + xx, y);
                        }

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
}