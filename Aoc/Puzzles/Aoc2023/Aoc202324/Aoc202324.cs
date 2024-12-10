using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

[Name("Never Tell Me The Odds")]
public class Aoc202324 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = CountIntersectingWithin2(input, 200_000_000_000_000, 400_000_000_000_000);

        return new PuzzleResult(result, "907db44ec104f348525996e3821ac11d");
    }
    
    public static int CountIntersectingWithin2(string s, long min, long max)
    {
        var count = 0;
        var hailstones = ParseHailstones(s);
        var seen = new HashSet<(long, long)>();
        foreach (var a in hailstones)
        {
            foreach (var b in hailstones)
            {
                if (a.Id == b.Id)
                    continue;

                List<Hailstone> both = [a, b];
                var first = both.MinBy(o => o.Id)!;
                var second = both.MaxBy(o => o.Id)!;
                var key = (first.Id, second.Id);
                if (!seen.Add(key))
                    continue;

                var intersection = first.IntersectsWith(second);
                if(intersection is null)
                    continue;

                var isInRange = intersection.X > min && intersection.X < max && intersection.Y > min && intersection.Y < max; 
                count += isInRange ? 1 : 0;
            }   
        }

        return count;
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = FindRockPosition(input);
        var sum = result.x + result.y + result.z;
        
        return new PuzzleResult(sum);
    }
    
    private static (long x, long y, long z) FindRockPosition(string s)
    {
        var allHailstones = ParseHailstones(s);
        var rangeSize = 500;
        var range = Enumerable.Range(-rangeSize, rangeSize).ToArray();

        var c = 500;
        while (c > 0)
        {
            c--;
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

                    if (intercepts.Count == 0)
                        continue;
                    
                    var first = intercepts.First()!;

                    if (intercepts.Count < 3)
                        continue;
                    
                    if (intercepts.All(o => Math.Abs(o.X - first.X) < Hailstone.DoubleTolerance) && 
                        intercepts.All(o => Math.Abs(o.Y - first.Y) < Hailstone.DoubleTolerance)
                    ) {
                        foreach (var dvz in range)
                        {
                            var z1 = hailstones[1].TestZ(intercepts[0].Time, dvz);
                            var z2 = hailstones[2].TestZ(intercepts[1].Time, dvz);
                            var z3 = hailstones[3].TestZ(intercepts[2].Time, dvz);
                            if (Math.Abs(z1 - z2) < Hailstone.DoubleTolerance && Math.Abs(z2 - z3) < Hailstone.DoubleTolerance)
                            {
                                return ((long)intercepts.First().X, (long)intercepts.First().Y, (long)z1);
                            }
                        }
                    }
                }   
            }
        }

        return (0, 0, 0);
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
}