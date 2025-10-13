using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202406;

[Name("Guard Gallivant")]
public class Aoc202406 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var startCoord = matrix.FindAddresses('^').First();
        var visitCount = GetVisitCount(matrix, startCoord) ?? 0;
        
        return new PuzzleResult(visitCount, "471731c253513e4cf775d088dc806f6a");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var startCoord = matrix.FindAddresses('^').First();
        var visited = GetVisited(matrix, startCoord);
        var loopCount = visited!.Sum(blockedCoord => GetVisitCount(matrix, startCoord, blockedCoord) is null ? 1 : 0);

        return new PuzzleResult(loopCount, "ff1f7615465eed4279ca5994cb797751");
    }

    private static int? GetVisitCount(
        Grid<char> grid,
        Coord startCoord,
        Coord? blockedCoord = null) =>
        GetVisited(grid, startCoord, blockedCoord)?.Count;
    
    private static HashSet<Coord>? GetVisited(Grid<char> grid, Coord startCoord, Coord? blockedCoord = null)
    {
        var cache = new HashSet<(Coord, GridDirection)>();
        var visited = new HashSet<Coord>();
        
        grid.MoveTo(startCoord);
        grid.TurnTo(GridDirection.Up);
        visited.Add(grid.Address);
        
        while (true)
        {
            if (!grid.TryMoveForward())
                break;

            if (grid.Address.Equals(blockedCoord) || grid.ReadValue() == '#')
            {
                grid.MoveBackward();
                grid.TurnRight();
                continue;
            }
            
            if(cache.Contains((grid.Address, grid.Direction)))
                return null;
            
            visited.Add(grid.Address);
            cache.Add((grid.Address, grid.Direction));
        }

        return visited;
    }
}