using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202406;

[IsSlow]
[Comment("Many matrix loops")]
[Name("Guard Gallivant")]
public class Aoc202406 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var visitCount = GetVisitCount(matrix) ?? 0;
        
        return new PuzzleResult(visitCount, "471731c253513e4cf775d088dc806f6a");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);

        var blockedCoords = matrix.Coords.Where(o => matrix.ReadValueAt(o) != '#' && matrix.ReadValueAt(o) != '^');

        var loopCount = 0;
        foreach (var blockedCoord in blockedCoords)
        {
            var copy = matrix.Clone();
            loopCount += GetVisitCount(copy, blockedCoord) is null ? 1 : 0;
        }
        
        return new PuzzleResult(loopCount, "ff1f7615465eed4279ca5994cb797751");
    }
    
    private static int? GetVisitCount(Matrix<char> matrix, MatrixAddress? blockedCoord = null)
    {
        var startCoord = matrix.FindAddresses('^').First();
        var cache = new HashSet<(MatrixAddress, MatrixDirection)>();
        
        if(blockedCoord is not null)
            matrix.WriteValueAt(blockedCoord, '#');
        
        matrix.MoveTo(startCoord);
        matrix.TurnTo(MatrixDirection.Up);
        matrix.WriteValue('X');
        
        while (true)
        {
            if (!matrix.TryMoveForward())
                break;

            if (matrix.ReadValue() == '#')
            {
                matrix.MoveBackward();
                matrix.TurnRight();
                continue;
            }
            
            if(cache.Contains((matrix.Address, matrix.Direction)))
                return null;
            
            matrix.WriteValue('X');
            cache.Add((matrix.Address, matrix.Direction));
        }

        return matrix.FindAddresses('X').Count;
    }
}