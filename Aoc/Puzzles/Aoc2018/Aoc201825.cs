using System.Collections.Immutable;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Four-Dimensional Adventure")]
public class Aoc201825 : AocPuzzle
{
    [Puzzle("d346cc690c1ce3f1e472e11a710e1982")]
    public int Part1(string input) => new ConstellationFinder(input).Find();
    
    public class ConstellationFinder(string input)
    {
        private readonly IList<Point4d> _points = ParsePoints(input);

        private static IList<Point4d> ParsePoints(string input) => input.Split(LineBreaks.Single).Select(ParsePoint).ToList();
    
        private static Point4d ParsePoint(string s)
        {
            var coords = s.Trim().Split(',').Select(int.Parse).ToList();
            return new Point4d(coords[0], coords[1], coords[2], coords[3]);
        }

        public int Find()
        {
            var constellations = new List<Constellation>();

            foreach (var point in _points)
            {
                var constellation = constellations.FirstOrDefault(o => o.IsClose(point));
                if (constellation == null)
                {
                    constellation = new Constellation();
                    constellations.Add(constellation);
                }
                constellation.Add(point);
            }

            var lastConstellationCount = 0;
            while (constellations.Count != lastConstellationCount)
            {
                lastConstellationCount = constellations.Count;
                var mergedConstellations = new List<Constellation>();
                while (constellations.Any())
                {
                    var constellation = constellations.First();
                    constellations.RemoveAt(0);
                    var matchingConstellation = constellations.FirstOrDefault(o => o.IsClose(constellation));
                    if (matchingConstellation != null)
                    {
                        matchingConstellation.Add(constellation);
                    }
                    else
                    {
                        mergedConstellations.Add(constellation);
                    }
                }

                constellations = mergedConstellations;
            }

            return constellations.Count;
        }
    }
    
    public class Constellation
    {
        private readonly List<Point4d> _points = [];
        public IReadOnlyList<Point4d> Points => _points.ToImmutableList();

        public bool IsClose(Point4d point) => Points.Any(o => o.ManhattanDistanceTo(point) < 4);
        public bool IsClose(Constellation otherConstellation) => otherConstellation.Points.Any(IsClose);
        public void Add(Point4d point) => _points.Add(point);
        public void Add(Constellation constellation) => _points.AddRange(constellation.Points);
    }
    
    public record Point4d(int W, int X, int Y, int Z)
    {
        public int ManhattanDistanceTo(Point4d other) => ManhattanDistanceTo(other.W, other.X, other.Y, other.Z);
        private int ManhattanDistanceTo(int w, int x, int y, int z) => GetDistance(W, w) + GetDistance(X, x) + GetDistance(Y, y) + GetDistance(Z, z);
        private int GetDistance(int a, int b) => Math.Max(a, b) - Math.Min(a, b);
    }
}