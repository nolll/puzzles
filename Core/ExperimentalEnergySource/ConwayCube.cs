using System.Linq;
using Core.Tools;

namespace Core.ExperimentalEnergySource
{
    public class ConwayCube
    {
        public int Boot(string input, int iterations)
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

                matrix = newMatrix;
            }
            return matrix.Values.Count(o => o == '#');
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