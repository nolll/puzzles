using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202510;

[Name("Feast on the Board")]
public class Ece202510 : EverybodyEventPuzzle
{
    private readonly (int x, int y)[] _deltas = [
        (1, -2),
        (2, -1),
        (2, 1),
        (1, 2),
        (-1, 2),
        (-2, 1),
        (-2, -1),
        (-1, -2)
    ];

    public PuzzleResult Part1(string input) => new(Part1(input, 4), "742e9c5b98a1f2e9dfe76f5e8a1f560d");

    public int Part1(string input, int moveCount)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var dragonPos = grid.Coords.First(o => grid.ReadValueAt(o) == 'D');
        HashSet<Coord> visited = [dragonPos];
        List<Coord> queue = [dragonPos];
        for (var i = 0; i < moveCount; i++)
        {
            var newCoords = new List<Coord>();
            foreach (var coord in queue)
            {
                var coords = _deltas.Select(o => new Coord(coord.X + o.x, coord.Y + o.y))
                    .Where(o => !visited.Contains(o))
                    .Where(o => !grid.IsOutOfRange(o))
                    .ToList();
                
                visited.AddRange(coords);
                newCoords.AddRange(coords);
            }
            
            queue = newCoords;
        }

        return visited.Count(o => grid.ReadValueAt(o) == 'S');
    }

    public PuzzleResult Part2(string input) => new(Part2(input, 20), "c092efde26d8cc546f5805df698cf529");

    public int Part2(string input, int moveCount)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var dragon = grid.Coords.First(o => grid.ReadValueAt(o) == 'D');
        var sheep = grid.Coords.Where(o => grid.ReadValueAt(o) == 'S').ToHashSet();
        var eaten = 0;
        var hideouts = grid.Coords.Where(o => grid.ReadValueAt(o) == '#').ToHashSet();
        HashSet<Coord> queue = [dragon];
        for (var i = 0; i < moveCount; i++)
        {
            var dragons = new HashSet<Coord>();
            foreach (var coord in queue)
            {
                var coords = _deltas.Select(o => new Coord(coord.X + o.x, coord.Y + o.y))
                    .Where(o => !grid.IsOutOfRange(o))
                    .ToList();
                
                dragons.AddRange(coords);
            }

            foreach (var coord in dragons)
            {
                if(!hideouts.Contains(coord) && sheep.Contains(coord))
                {
                    sheep.Remove(coord);
                    eaten++;
                }
            }

            var newSheep = new HashSet<Coord>();
            foreach (var coord in sheep)
            {
                var newCoord = new Coord(coord.X, coord.Y + 1);
                if (!grid.IsOutOfRange(newCoord))
                    newSheep.Add(newCoord);
            }

            sheep = newSheep;
            
            foreach (var coord in dragons)
            {
                if(!hideouts.Contains(coord) && sheep.Contains(coord))
                {
                    sheep.Remove(coord);
                    eaten++;
                }
            }
            
            queue = dragons;
        }

        return eaten;
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}