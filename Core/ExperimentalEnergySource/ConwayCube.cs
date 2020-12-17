using System;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.ExperimentalEnergySource
{
    public class ConwayCube
    {
        public int Boot3D(string input, int iterations)
        {
            var matrix = Matrix3DBuilder.BuildCharMatrix(input, '.');

            for (var i = 0; i < iterations; i++)
            {
                matrix.ExtendAllDirections();
                var newMatrix = new Matrix3D<char>(1, 1, 1, '.');
                for (var z = 0; z < matrix.Depth; z++)
                {
                    for (var y = 0; y < matrix.Height; y++)
                    {
                        for (var x = 0; x < matrix.Width; x++)
                        {
                            matrix.MoveTo(x, y, z);
                            var currentValue = matrix.ReadValue();
                            var adjacentValues = matrix.Adjacent26;
                            var neighborCount = adjacentValues.Count(o => o == '#');
                            var newValue = GetNewValue(currentValue, neighborCount);
                            newMatrix.MoveTo(x, y, z);
                            newMatrix.WriteValue(newValue);
                        }
                    }
                }

                newMatrix.StartAddress = matrix.StartAddress;
                matrix = newMatrix;
            }
            return matrix.Values.Count(o => o == '#');  
        }

        public int Boot4D(string input, int iterations)
        {
            var matrix = Matrix4DBuilder.BuildCharMatrix(input, '.');

            for (var i = 0; i < iterations; i++)
            {
                matrix.ExtendAllDirections();
                var newMatrix = new Matrix4D<char>(1, 1, 1, 1, '.');
                for (var w = 0; w < matrix.Duration; w++)
                {
                    for (var z = 0; z < matrix.Depth; z++)
                    {
                        for (var y = 0; y < matrix.Height; y++)
                        {
                            for (var x = 0; x < matrix.Width; x++)
                            {
                                matrix.MoveTo(x, y, z, w);
                                var currentValue = matrix.ReadValue();
                                var adjacentValues = matrix.Adjacent80;
                                var neighborCount = adjacentValues.Count(o => o == '#');
                                var newValue = GetNewValue(currentValue, neighborCount);
                                newMatrix.MoveTo(x, y, z, w);
                                newMatrix.WriteValue(newValue);
                            }
                        }
                    }
                }

                newMatrix.StartAddress = matrix.StartAddress;
                matrix = newMatrix;

            }
            return matrix.Values.Count(o => o == '#');
        }

        private string Print(Matrix4D<char> matrix)
        {
            var s = new StringBuilder();
            for (var w = 0; w < matrix.Duration; w++)
            {
                for (var z = 0; z < matrix.Depth; z++)
                {
                    s.AppendLine($"z={z - matrix.StartAddress.Z} w={w - matrix.StartAddress.W}");
                    s.AppendLine(matrix.PrintLevel(w, z));
                    s.AppendLine();
                }
            }

            return s.ToString();
        }

        private char GetNewValue(char currentValue, int neighborCount)
        {
            if (currentValue == '#' && neighborCount != 2 && neighborCount != 3)
                return '.';

            if (currentValue == '.' && neighborCount == 3)
                return '#';

            return currentValue;
        }
    }
}