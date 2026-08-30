using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
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
        var lines = input.Split(LineBreaks.Single);
        var beacons = new Dictionary<char, Coord>();
        var lights = new HashSet<Coord>();
        var (sx, sy) = Numbers.IntsFromString(lines[0]);
        var (ax, ay) = Numbers.IntsFromString(lines[1]);
        beacons['A'] = new Coord(ax, ay);
        var (bx, by) = Numbers.IntsFromString(lines[2]);
        beacons['B'] = new Coord(bx, by);
        var (cx, cy) = Numbers.IntsFromString(lines[3]);
        beacons['C'] = new Coord(cx, cy);
        var moves = lines[4].Split('=').Last().ToCharArray();
        var currentPos = new Coord(sx, sy);
        lights.Add(currentPos);

        foreach (var move in moves)
        {
            var beaconPos = beacons[move];
            var maxX = Math.Max(currentPos.X, beaconPos.X);
            var minX = Math.Min(currentPos.X, beaconPos.X);
            var maxY = Math.Max(currentPos.Y, beaconPos.Y);
            var minY = Math.Min(currentPos.Y, beaconPos.Y);
            var diffX = maxX - minX;
            var diffY = maxY - minY;
            var distX = (float)diffX / 2;
            var distY = (float)diffY / 2;
            var newX = (int)Math.Floor(maxX - distX);
            var newY = (int)Math.Floor(maxY - distY);
            currentPos = new Coord(newX, newY);
            lights.Add(currentPos);
        }
        
        return lights.Count;
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
}