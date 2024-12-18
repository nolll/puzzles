using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202418;

[Name("RAM Run")]
public class Aoc202418 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var res = Part1(input, 1024, 71, 71);
        
        return new PuzzleResult(res, "4cfa9a7af37f61d855606a891023473a");
    }
    
    public PuzzleResult Part2(string input)
    {
        var res = Part2(input, 1024, null, 71, 71);
        
        return new PuzzleResult(res, "5cc0c24dab0cf72c881e5a427edc0e1b");
    }
    
    public int Part1(string input, int steps, int width, int height)
    {
        var coords = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o[0], o[1]))
            .Take(steps);

        var matrix = new Matrix<char>(width, height, '.');
        foreach (var coord in coords)
        {
            matrix.WriteValueAt(coord, '#');
        }

        var start = new MatrixAddress(0, 0);
        var end = new MatrixAddress(matrix.XMax, matrix.YMax);

        return PathFinder.ShortestPathTo(matrix, start, end).Count;
    }

    public string Part2(string input, int from, int? steps, int width, int height)
    {
        var coords = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o[0], o[1]))
            .ToArray();

        var bytes = steps ?? coords.Length;

        var matrix = new Matrix<char>(width, height, '.');
        var start = new MatrixAddress(0, 0);
        var end = new MatrixAddress(matrix.XMax, matrix.YMax);

        for (var i = 0; i < bytes; i++)
        {
            var coord = coords[i];
            matrix.WriteValueAt(coord, '#');

            if (i <= from) 
                continue;
            
            var r = PathFinder.ShortestPathTo(matrix, start, end);
            if (r.Count == 0)
                return coord.Id;
        }

        return "";
    }
}