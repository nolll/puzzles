using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.CoordinateSystems.CoordinateSystem4D;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202017;

public class ConwayCube
{
    public int Boot3D(string input, int iterations)
    {
        var matrix = Matrix3DBuilder.BuildCharMatrix(input, '.');

        for (var i = 0; i < iterations; i++)
        {
            matrix.ExtendAllDirections();
            var ons = new List<Matrix3DAddress>();
            for (var z = matrix.ZMin; z <= matrix.ZMax; z++)
            {
                for (var y = matrix.YMin; y <= matrix.YMax; y++)
                {
                    for (var x = matrix.XMin; x <= matrix.XMax; x++)
                    {
                        matrix.MoveTo(x, y, z);
                        var currentValue = matrix.ReadValue();
                        var adjacentValues = matrix.AllAdjacentValues;
                        var neighborCount = adjacentValues.Count(o => o == '#');
                        var newValue = GetNewValue(currentValue, neighborCount);
                        if(newValue == '#')
                            ons.Add(matrix.Address);
                    }
                }
            }
            
            matrix.Clear();
            foreach (var coord in ons) 
                matrix.WriteValueAt(coord, '#');

            //var p1after = matrix.Print(-1);
            //var p2after = matrix.Print(0);
            //var p3after = matrix.Print(1);

            //var xxxx = 0;
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
                            var adjacentValues = matrix.AllAdjacentValues;
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

    private static char GetNewValue(char currentValue, int neighborCount)
    {
        if (currentValue == '#' && neighborCount != 2 && neighborCount != 3)
            return '.';

        if (currentValue == '.' && neighborCount == 3)
            return '#';

        return currentValue;
    }
}