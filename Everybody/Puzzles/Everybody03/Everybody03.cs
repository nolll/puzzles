using System.Numerics;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody03;

[Name("Mining Maestro")]
public class Everybody03() : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = Run(input, false);
        return new PuzzleResult(result, "f8809d3064586fdc87c819e0caa76093");
    }
    
    protected override PuzzleResult RunPart2(string input)
    {
        var result = Run(input, false);
        return new PuzzleResult(result, "d6f8a8bfba935c69e51e8d3249dc7264");
    }

    protected override PuzzleResult RunPart3(string input)
    {
        var result = Run(input, true);
        return new PuzzleResult(result, "b37fb7a9a2f7e97880544e19b5c4e323");
    }
    
    public static int Run(string input, bool includeDiagonal = false)
    {
        var charMatrix = MatrixBuilder.BuildCharMatrix(input);
        var matrix = new Matrix<int>(charMatrix.Width, charMatrix.Height);
        var coords = new List<MatrixAddress>();
        var digLevel = 1;
        
        foreach (var coord in charMatrix.Coords)
        {
            if (charMatrix.ReadValueAt(coord) == '#')
            {
                coords.Add(coord);
                matrix.WriteValueAt(coord, digLevel);
            }
        }

        var requiredNeighbors = includeDiagonal ? 8 : 4;
        
        while (coords.Count > 0)
        {
            var nextCoords = new List<MatrixAddress>();
            foreach (var coord in coords)
            {
                var neighbors = includeDiagonal
                    ? matrix.AllAdjacentValuesTo(coord)
                    : matrix.OrthogonalAdjacentValuesTo(coord);
                
                if (neighbors.Count == requiredNeighbors && neighbors.All(o => o >= digLevel))
                {
                    matrix.WriteValueAt(coord, digLevel + 1);
                    nextCoords.Add(coord);
                }
            }
            digLevel++;
            coords = nextCoords;
        }
        
        return matrix.Values.Sum();
    }
}