using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202218;

[Comment("The 3d matrix is a little broken")]
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
            foreach (var b in cubes)
            {
                if (!b.Equals(a))
                {
                    a.AdjustTotalArea(b);
                }
            }
        }

        return cubes.Sum(o => o.AdjustedArea);
    }

    public int Part2(string input)
    {
        var padding = 1;

        var cubes = StringReader.ReadLines(input)
            .Select(o => o.Split(',').ToArray())
            .Select(o => new Cube(int.Parse(o[0]) + padding, int.Parse(o[1]) + padding, int.Parse(o[2]) + padding))
            .ToList();

        var width = cubes.Select(o => o.X).Max() + padding * 2;
        var height = cubes.Select(o => o.Y).Max() + padding * 2;
        var depth = cubes.Select(o => o.Z).Max() + padding * 2;

        var matrix = new Matrix3D<char>(width, height, depth, '.');
        foreach (var cube in cubes)
        {
            matrix.MoveTo(cube.X, cube.Y, cube.Z);
            matrix.WriteValue('#');
        }

        var start = new Matrix3DAddress(0, 0, 0);
        var queue = new Queue<Matrix3DAddress>();
        queue.Enqueue(start);
        var seen = new HashSet<Matrix3DAddress>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            matrix.MoveTo(current);
            matrix.WriteValue('~');
            var adjacent = matrix.OrthogonalAdjacentCoords;
            var validAdjacent = adjacent.Where(o => !seen.Contains(o) && matrix.ReadValueAt(o) == '.');
            foreach (var c in validAdjacent)
            {
                seen.Add(c);
                queue.Enqueue(c);
            }
        }

        var trappedCoords = new List<Matrix3DAddress>();
        for (var x = matrix.XMin; x <= matrix.XMax; x++)
        {
            for (var y = matrix.YMin; y <= matrix.YMax; y++)
            {
                for (var z = matrix.ZMin; z <= matrix.ZMax; z++)
                {
                    var c = new Matrix3DAddress(x, y, z);
                    if (matrix.ReadValueAt(c) == '.')
                        trappedCoords.Add(c);
                }
            }
        }

        foreach (var a in cubes)
        {
            foreach (var b in cubes)
            {
                if (!b.Equals(a))
                {
                    a.AdjustTotalArea(b);
                }
            }
        }

        var trappedCubes = trappedCoords.Select(o => new Cube(o.X, o.Y, o.Z)).ToList();
        foreach (var a in trappedCubes)
        {
            foreach (var b in trappedCubes)
            {
                if (!b.Equals(a))
                {
                    a.AdjustTotalArea(b);
                }
            }
        }

        var cubeTotalArea = cubes.Sum(o => o.AdjustedArea);
        var trappedTotalArea = trappedCubes.Sum(o => o.AdjustedArea);

        return cubeTotalArea - trappedTotalArea;
    }

    private class Cube
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        private int _subtractedArea;
        private const int FullArea = 6;

        public Cube(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

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