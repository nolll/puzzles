using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201825;

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