using System.Runtime.InteropServices;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Phantasmagorithm")]
public class Ece202610 : EverybodyEventPuzzle
{
    [Puzzle("34c994b8cccebc2847539a353f621586")]
    public long Part1(string input)
    {
        var (ghosts, walls) = Parse(input);

        for (var i = 0; i < 10; i++)
            RunRound(ghosts, walls, int.MaxValue);

        return ghosts.Sum(o => o.Collisions);
    }

    [Puzzle("7e09ad37dfd834287b97159cd2439fcc")]
    public int Part2(string input)
    {
        var (ghosts, walls) = Parse(input);

        var rounds = 0;
        while (ghosts.Count > 0)
        {
            RunRound(ghosts, walls, 10_000);
            rounds++;
        }

        return rounds;
    }

    [Puzzle("c6f1451be21edd9fc4df9e17bc8f3bbd")]
    public long Part3(string input)
    {
        const long limit = 1_000_000_000_000;
        var (ghosts, walls) = Parse(input);

        var round = 0L;
        var seen = new Dictionary<string, (long round, Dictionary<int, long> count)>();
        while (ghosts.Count > 0)
        {
            RunRound(ghosts, walls, limit);
            var key = string.Join(',', ghosts.Select(o => o.ToString()));
            var ghostCollisions = ghosts.ToDictionary(k => k.Id, k => k.Collisions);

            if (!seen.TryAdd(key, (round, ghostCollisions)))
            {
                var (lastRound, lastCollitions) = seen[key];
                var roundsPerStep = round - lastRound;
                var steps = long.MaxValue;

                foreach (var ghost in ghosts)
                {
                    var currentCollisions = ghostCollisions[ghost.Id];
                    var lastCollisions = lastCollitions[ghost.Id];
                    var diff = currentCollisions - lastCollisions;
                    var distanceLeft = limit - ghost.Collisions;

                    steps = Math.Min(steps, distanceLeft / diff);
                }

                // We skip to much in the last step without this
                if (steps > 1)
                    steps--;

                round += roundsPerStep * steps;

                foreach (var ghost in ghosts)
                {
                    var currentCollisions = ghostCollisions[ghost.Id];
                    var lastCollisions = lastCollitions[ghost.Id];
                    var diff = currentCollisions - lastCollisions;
                    ghost.Collisions += diff * steps;
                }
            }

            round++;
        }

        return round;
    }

    private static void RunRound(List<Ghost> ghosts, HashSet<Coord> walls, long collisionLimit)
    {
        MoveGhosts(ghosts, walls);
        RemoveGhosts(ghosts, collisionLimit);
        HandleCollisions(ghosts);
        RemoveGhosts(ghosts, collisionLimit);
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

    private static void RemoveGhosts(List<Ghost> ghosts, long collisionLimit)
    {
        var ghostsToRemove = ghosts.Where(o => o.Collisions >= collisionLimit).ToList();

        foreach (var ghost in ghostsToRemove)
            ghosts.Remove(ghost);
    }

    private static (List<Ghost> ghosts, HashSet<Coord> walls) Parse(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var walls = grid.Coords.Where(o => grid.ReadValueAt(o) == '#').ToHashSet();
        var ghosts = new List<Ghost>();

        var id = 1;
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v is '#' or '.')
                continue;

            ghosts.Add(new Ghost(id, coord, GridDirection.Get(v)));
            grid.WriteValueAt(coord, '.');
            id++;
        }

        return (ghosts, walls);
    }

    private class Ghost(int id, Coord coord, GridDirection direction) : IEquatable<Ghost>
    {
        public int Id { get; } = id;
        public Coord Coord { get; set; } = coord;
        public GridDirection Direction { get; set; } = direction;
        public long Collisions { get; set; }

        public override string ToString() => $"{Id}{Coord.Id}|{Direction.Name}";

        public bool Equals(Ghost? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Ghost)obj);
        }

        public override int GetHashCode() => Id;
    }
}