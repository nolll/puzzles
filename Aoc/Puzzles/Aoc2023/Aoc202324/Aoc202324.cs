using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

[Name("Never Tell Me The Odds")]
public class Aoc202324(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = CountIntersectingWithin(input, 200_000_000_000_000, 400_000_000_000_000);

        return new PuzzleResult(result, "907db44ec104f348525996e3821ac11d");
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    public static int CountIntersectingWithin(string s, long min, long max)
    {
        var lines = StringReader.ReadLines(s);
        var hailstones = lines.Select(o => o.Replace(" @", ",").Replace(" ", "").Split(',')
            .Select(long.Parse).ToArray())
            .Select((o, i) => new Hailstone(i, o[0], o[1], o[2], o[3], o[4], o[5]))
            .ToList();

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