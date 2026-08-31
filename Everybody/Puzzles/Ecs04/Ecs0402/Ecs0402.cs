using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0402;

[Name("Sir Sierpiński's Sparkballs")]
public class Ecs0402 : EverybodyStoryPuzzle
{
    [Puzzle("fb692b7205b0bd08a28cb70fc32d69ae")]
    public int Part1(string input)
    {
        var lights = new HashSet<Coord>();
        var (currentPos, beacons, moves) = Parse(input);
        lights.Add(currentPos);

        foreach (var move in moves)
        {
            currentPos = GetNextPos(currentPos, beacons[move]);
            lights.Add(currentPos);
        }
        
        return lights.Count;
    }

    [Puzzle("f134d7f2d8196d3bea44812a12cdf169")]
    public int Part2(string input)
    {
        var lights = new HashSet<Coord>();
        var (currentPos, beacons, moves) = Parse(input);
        lights.Add(currentPos);

        foreach (var move in moves)
        {
            currentPos = GetNextPos(currentPos, beacons[move]);
            lights.Add(currentPos);
        }

        return CountFireFlies(lights);
    }

    [Puzzle("78153ed03b4013c9023ede0fe313fd8e")]
    public int Part3(string input)
    {
        var lights = new HashSet<Coord>();
        var (startPos, beacons, _) = Parse(input);

        var queue = new Queue<Coord>([startPos]);
        while (queue.Count > 0)
        {
            var currentPos = queue.Dequeue();
            lights.Add(currentPos);
            foreach (var beaconPos in beacons.Values)
            {
                var newPos = GetNextPos(currentPos, beaconPos);
                if(!lights.Contains(newPos))
                    queue.Enqueue(newPos);
            }
        }

        return CountFireFlies(lights);
    }
    
    private static Coord GetNextPos(Coord current, Coord beacon)
    {
        var (maxx, maxy) = (Math.Max(current.X, beacon.X), Math.Max(current.Y, beacon.Y));
        var (minx, miny) = (Math.Min(current.X, beacon.X), Math.Min(current.Y, beacon.Y));
        
        return new Coord(
            (int)Math.Floor(maxx - (float)(maxx - minx) / 2), 
            (int)Math.Floor(maxy - (float)(maxy - miny) / 2));
    }

    private static int CountFireFlies(HashSet<Coord> lights)
    {
        var fireflies = new HashSet<Coord>();
        
        foreach (var light in lights)
        {
            var flies = Grid<int>.PossibleOrthogonalAdjacentCoordsTo(light)
                .Where(o => !lights.Contains(o));
            fireflies.AddRange(flies);
        }
        
        return fireflies.Count(o => !lights.Contains(o));
    }

    private static (Coord, Dictionary<char, Coord>, char[]) Parse(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var s = Coord.FromArray(Numbers.IntsFromString(lines[0]));
        var beacons = new Dictionary<char, Coord>
        {
            ['A'] = Coord.FromArray(Numbers.IntsFromString(lines[1])),
            ['B'] = Coord.FromArray(Numbers.IntsFromString(lines[2])),
            ['C'] = Coord.FromArray(Numbers.IntsFromString(lines[3]))
        };
        var moves = lines.Length == 5 ? lines[4].Split('=').Last().ToCharArray() : [];

        return (s, beacons, moves);
    }
}