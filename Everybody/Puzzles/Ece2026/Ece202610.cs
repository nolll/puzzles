using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Phantasmagorithm")]
public class Ece202610 : EverybodyEventPuzzle
{
    [Puzzle("34c994b8cccebc2847539a353f621586")]
    public int Part1(string input)
    {
        var (ghosts, walls) = Parse(input);
        
        for (var i = 0; i < 10; i++) 
            RunRound(ghosts, walls);
        
        return ghosts.Sum(o => o.Collisions);
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
    
    private static void RunRound(List<Ghost> ghosts, HashSet<Coord> walls)
    {
        MoveGhosts(ghosts, walls);
        HandleCollisions(ghosts);
    }

    private static void HandleCollisions(List<Ghost> ghosts)
    {
        var collidingGhosts = ghosts.GroupBy(o => o.Coord);
        foreach (var ghostGroup in collidingGhosts.Where(o => o.Count() > 1))
        {
            foreach (var ghost in ghostGroup)
            {
                ghost.Direction = ghost.Direction.TurnAround();
                ghost.Collisions++;
            }
        }
    }

    private static void MoveGhosts(List<Ghost> ghosts, HashSet<Coord> walls)
    {
        foreach (var ghost in ghosts)
        {
            var nextCoord = ghost.Coord.Forward(ghost.Direction);
            if (walls.Contains(nextCoord))
            {
                ghost.Direction = ghost.Direction.TurnRight();
                ghost.Collisions++;
            }
            else
            {
                ghost.Coord = nextCoord;
            }
        }
    }
    
    private static (List<Ghost> ghosts, HashSet<Coord> walls) Parse(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var walls = grid.Coords.Where(o => grid.ReadValueAt(o) == '#').ToHashSet();
        var ghosts = new List<Ghost>();

        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v is not '#' and not '.')
            {
                ghosts.Add(new Ghost(coord, GridDirection.Get(v)));
                grid.WriteValueAt(coord, '.');
            }
        }

        return (ghosts, walls);
    }

    private class Ghost(Coord coord, GridDirection direction)
    {
        public Coord Coord { get; set; } = coord;
        public GridDirection Direction { get; set; } = direction;
        public int Collisions { get; set; }
    }
}