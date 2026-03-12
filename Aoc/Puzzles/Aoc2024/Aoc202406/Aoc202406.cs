using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202406;

[Name("Guard Gallivant")]
public class Aoc202406 : AocPuzzle
{
    [Puzzle("471731c253513e4cf775d088dc806f6a")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var startCoord = grid.FindAddresses('^').First();
        return GetVisitCount(grid, startCoord) ?? 0;
    }

    [Puzzle("ff1f7615465eed4279ca5994cb797751")]
    public int Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var startCoord = grid.FindAddresses('^').First();
        return GetVisited(grid, startCoord)!.Count(o => GetVisitCount(grid, startCoord, o) is null);
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
        visited.Add(grid.Coord);
        
        while (true)
        {
            if (!grid.TryMoveForward())
                break;

            if (grid.Coord.Equals(blockedCoord) || grid.ReadValue() == '#')
            {
                grid.MoveBackward();
                grid.TurnRight();
                continue;
            }
            
            if(cache.Contains((grid.Coord, grid.Direction)))
                return null;
            
            visited.Add(grid.Coord);
            cache.Add((grid.Coord, grid.Direction));
        }

        return visited;
    }
}