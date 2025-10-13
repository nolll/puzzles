using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202406;

[Name("Guard Gallivant")]
public class Aoc202406 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var startCoord = matrix.FindAddresses('^').First();
        var visitCount = GetVisitCount(matrix, startCoord) ?? 0;
        
        return new PuzzleResult(visitCount, "471731c253513e4cf775d088dc806f6a");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var startCoord = matrix.FindAddresses('^').First();
        var visited = GetVisited(matrix, startCoord);
        var loopCount = visited!.Sum(blockedCoord => GetVisitCount(matrix, startCoord, blockedCoord) is null ? 1 : 0);

        return new PuzzleResult(loopCount, "ff1f7615465eed4279ca5994cb797751");
    }

    private static int? GetVisitCount(
        Matrix<char> matrix,
        Coord startCoord,
        Coord? blockedCoord = null) =>
        GetVisited(matrix, startCoord, blockedCoord)?.Count;
    
    private static HashSet<Coord>? GetVisited(Matrix<char> matrix, Coord startCoord, Coord? blockedCoord = null)
    {
        var cache = new HashSet<(Coord, MatrixDirection)>();
        var visited = new HashSet<Coord>();
        
        matrix.MoveTo(startCoord);
        matrix.TurnTo(MatrixDirection.Up);
        visited.Add(matrix.Address);
        
        while (true)
        {
            if (!matrix.TryMoveForward())
                break;

            if (matrix.Address.Equals(blockedCoord) || matrix.ReadValue() == '#')
            {
                matrix.MoveBackward();
                matrix.TurnRight();
                continue;
            }
            
            if(cache.Contains((matrix.Address, matrix.Direction)))
                return null;
            
            visited.Add(matrix.Address);
            cache.Add((matrix.Address, matrix.Direction));
        }

        return visited;
    }
}