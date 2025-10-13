using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202218;

public class LavaCubes
{
    public int Part1(string input)
    {
        var cubes = StringReader.ReadLines(input)
            .Select(o => o.Split(',').ToArray())
            .Select(o => new Cube(int.Parse(o[0]), int.Parse(o[1]), int.Parse(o[2])))
            .ToList();

        foreach (var a in cubes)
        {
            foreach (var b in cubes.Where(b => !b.Equals(a)))
            {
                a.AdjustTotalArea(b);
            }
        }

        return cubes.Sum(o => o.AdjustedArea);
    }

    public int Part2(string input)
    {
        const int padding = 1;

        var cubes = StringReader.ReadLines(input)
            .Select(o => o.Split(',').ToArray())
            .Select(o => new Cube(int.Parse(o[0]) + padding, int.Parse(o[1]) + padding, int.Parse(o[2]) + padding))
            .ToList();

        var width = cubes.Select(o => o.X).Max() + padding * 2;
        var height = cubes.Select(o => o.Y).Max() + padding * 2;
        var depth = cubes.Select(o => o.Z).Max() + padding * 2;

        var grid = new Grid3d<char>(width, height, depth, '.');
        foreach (var cube in cubes)
        {
            grid.MoveTo(cube.X, cube.Y, cube.Z);
            grid.WriteValue('#');
        }

        var start = new Coord3d(0, 0, 0);
        var queue = new Queue<Coord3d>();
        queue.Enqueue(start);
        var seen = new HashSet<Coord3d>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            grid.MoveTo(current);
            grid.WriteValue('~');
            var adjacent = grid.OrthogonalAdjacentCoords;
            var validAdjacent = adjacent.Where(o => !seen.Contains(o) && grid.ReadValueAt(o) == '.');
            foreach (var c in validAdjacent)
            {
                seen.Add(c);
                queue.Enqueue(c);
            }
        }

        var trappedCoords = new List<Coord3d>();
        for (var x = grid.XMin; x <= grid.XMax; x++)
        {
            for (var y = grid.YMin; y <= grid.YMax; y++)
            {
                for (var z = grid.ZMin; z <= grid.ZMax; z++)
                {
                    var c = new Coord3d(x, y, z);
                    if (grid.ReadValueAt(c) == '.')
                        trappedCoords.Add(c);
                }
            }
        }

        foreach (var a in cubes)
        {
            foreach (var b in cubes.Where(b => !b.Equals(a)))
            {
                a.AdjustTotalArea(b);
            }
        }

        var trappedCubes = trappedCoords.Select(o => new Cube(o.X, o.Y, o.Z)).ToList();
        foreach (var a in trappedCubes)
        {
            foreach (var b in trappedCubes.Where(b => !b.Equals(a)))
            {
                a.AdjustTotalArea(b);
            }
        }

        var cubeTotalArea = cubes.Sum(o => o.AdjustedArea);
        var trappedTotalArea = trappedCubes.Sum(o => o.AdjustedArea);

        return cubeTotalArea - trappedTotalArea;
    }

    private class Cube(int x, int y, int z)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public int Z { get; } = z;
        private int _subtractedArea;
        private const int FullArea = 6;

        public int AdjustedArea => FullArea - _subtractedArea;

        public void AdjustTotalArea(Cube other)
        {
            if (X == other.X + 1 && Y == other.Y && Z == other.Z)
                _subtractedArea += 1;
            if (X + 1 == other.X && Y == other.Y && Z == other.Z)
                _subtractedArea += 1;
            if (X == other.X && Y == other.Y + 1 && Z == other.Z)
                _subtractedArea += 1;
            if (X == other.X && Y + 1 == other.Y && Z == other.Z)
                _subtractedArea += 1;
            if (X == other.X && Y == other.Y && Z == other.Z + 1)
                _subtractedArea += 1;
            if (X == other.X && Y == other.Y && Z + 1 == other.Z)
                _subtractedArea += 1;
        }

        public bool Equals(Cube other) => X == other.X && Y == other.Y && Z == other.Z;
    }
}