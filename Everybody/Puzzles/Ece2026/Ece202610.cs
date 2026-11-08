using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Phantasmagorithm")]
public class Ece202610 : EverybodyEventPuzzle
{
    [Puzzle("34c994b8cccebc2847539a353f621586")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
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

        var collisionCount = 0;
        for (var i = 0; i < 10; i++)
        {
            var printGrid = grid.Clone();
            foreach (var ghost in ghosts)
            {
                printGrid.WriteValueAt(ghost.Coord, ghost.Direction.Name);
            }

            var print = printGrid.Print();
            
            foreach (var ghost in ghosts)
            {
                var nextCoord = ghost.Coord.Forward(ghost.Direction);
                var v = grid.ReadValueAt(nextCoord);
                if (v == '#')
                {
                    ghost.Direction = ghost.Direction.TurnRight();
                    collisionCount++;
                }
                else
                {
                    ghost.Coord = nextCoord;
                }
            }

            var collidingGhosts = ghosts.GroupBy(o => o.Coord);
            foreach (var ghostGroup in collidingGhosts.Where(o => o.Count() > 1))
            {
                foreach (var ghost in ghostGroup)
                {
                    ghost.Direction = ghost.Direction.TurnAround();
                    collisionCount++;
                }
            }
        }
        
        return collisionCount;
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

    private class Ghost(Coord coord, GridDirection direction)
    {
        public Coord Coord { get; set; } = coord;
        public GridDirection Direction { get; set; } = direction;
    }
}