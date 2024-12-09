using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

[Name("Never Tell Me The Odds")]
public class Aoc202324 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = CountIntersectingWithin(input, 200_000_000_000_000, 400_000_000_000_000);

        return new PuzzleResult(result, "907db44ec104f348525996e3821ac11d");
    }

    public PuzzleResult RunPart2(string input)
    {
        //var result = FindRockPosition(input);
        //var sum = result.x + result.y + result.z;
        var sum = 0;
        
        return new PuzzleResult(sum);
    }

    public static int CountIntersectingWithin(string s, long min, long max)
    {
        var hailstones = ParseHailstones(s);

        var count = 0;

        for (var i = 0; i < hailstones.Count; i++)
        {
            var ha = hailstones[i];
            for (var j = i; j < hailstones.Count; j++)
            {
                var hb = hailstones[j];
                if (ha.Id == hb.Id)
                    continue;

                var a = new Point(ha.X, ha.Y);
                var aLater = new Point(ha.X + ha.Vx, ha.Y + ha.Vy);

                var b = new Point(hb.X, hb.Y);
                var bLater = new Point(hb.X + hb.Vx, hb.Y + hb.Vy);

                var intersection = FindIntersection(a, aLater, b, bLater);
                if (intersection is null)
                    continue;

                var isOutOfRange = intersection.X < min || intersection.Y < min || intersection.X > max || intersection.Y > max;
                if (isOutOfRange)
                    continue;

                var aStartDistance = GetDistance(a, intersection);
                var aEndDistance = GetDistance(aLater, intersection);
                var bStartDistance = GetDistance(b, intersection);
                var bEndDistance = GetDistance(bLater, intersection);

                var isMovingAway = aEndDistance >= aStartDistance || bEndDistance >= bStartDistance;
                if (isMovingAway)
                    continue;

                count++;
            }
        }

        return count;
    }
    
    public static (long x, long y, long z) FindRockPosition(string s)
    {
        var allHailstones = ParseHailstones(s);
        var range = Enumerable.Range(-500, 500).ToArray();

        var c = 0;
        while (true)
        {
            c++;
            Console.WriteLine(c);
            var hailstones = GetRandomHailstones(allHailstones).ToList();
            foreach (var dvx in range)
            {
                foreach (var dvy in range)
                {
                    var hail0 = hailstones[0].WithVelocityDelta(dvx, dvy);
                    var intercepts = hailstones
                        .Skip(1)
                        .Select(o => o.WithVelocityDelta(dvx, dvy).IntersectsWith(hail0))
                        .Where(o => o is not null)
                        .ToList();

                    var first = intercepts.FirstOrDefault();
                    if(first is null)
                        continue;
                    
                    if (intercepts.Count == 3 &&
                        intercepts.All(o => o.X == first.X) &&
                        intercepts.All(o => o.Y == first.Y)
                    ) {
                        foreach (var dvz in range)
                        {
                            var z1 = hailstones[1].TestZ(intercepts[0].Time, dvz);
                            var z2 = hailstones[2].TestZ(intercepts[1].Time, dvz);
                            var z3 = hailstones[3].TestZ(intercepts[2].Time, dvz);
                            if (z1 == z2 && z2 == z3)
                            {
                                return ((long)intercepts.First().X, (long)intercepts.First().Y, (long)z1);
                            }
                        }
                    }
                }   
            }
        }
    }

    private static List<Hailstone> ParseHailstones(string s)
    {
        var lines = StringReader.ReadLines(s);
        return lines.Select(o => o.Replace(" @", ",").Replace(" ", "").Split(',').Select(long.Parse).ToArray())
            .Select((o, i) => new Hailstone(i, o[0], o[1], o[2], o[3], o[4], o[5]))
            .ToList();
    }

    private static IEnumerable<Hailstone> GetRandomHailstones(List<Hailstone> hailstones)
    {
        var totalCount = hailstones.Count;
        var set = new HashSet<int>();
        var random = new Random();
        while (set.Count < 4)
        {
            set.Add(random.Next(totalCount));
        }

        foreach (var index in set)
        {
            yield return hailstones[index];
        }
    }

    private static double GetDistance(Point a, Point b)
    {
        var xd = Math.Abs(a.X - b.X);
        var yd = Math.Abs(a.Y - b.Y);
        return Math.Sqrt(xd * xd + yd + yd);
    }

    private static Point? FindIntersection(Point a, Point b, Point c, Point d)
    {
        var a1 = b.Y - a.Y;
        var b1 = a.X - b.X;
        var c1 = a1 * a.X + b1 * a.Y;

        var a2 = d.Y - c.Y;
        var b2 = c.X - d.X;
        var c2 = a2 * c.X + b2 * c.Y;

        var determinant = a1 * b2 - a2 * b1;

        if (determinant == 0)
            return null;

        var x = (b2 * c1 - b1 * c2) / determinant;
        var y = (a1 * c2 - a2 * c1) / determinant;

        return new Point(x, y);
    }
}