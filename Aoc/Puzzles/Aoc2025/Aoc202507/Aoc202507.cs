using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202507;

[Name("Laboratories")]
public class Aoc202507 : AocPuzzle
{
    private const int Splitter = '^';
    private const char Start = 'S';

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var beams = grid.FindAddresses(Start).ToHashSet();
        var splitCount = 0;
        var y = 0;
        while (y < grid.YMax)
        {
            var newBeams = new HashSet<Coord>();
            foreach (var beam in beams.Select(beam => new Coord(beam.X, y)))
            {
                if (grid.ReadValueAt(beam) == Splitter)
                {
                    newBeams.Add(new Coord(beam.X - 1, y));
                    newBeams.Add(new Coord(beam.X + 1, y));
                    splitCount++;
                }
                else
                {
                    newBeams.Add(beam);
                }
            }

            beams = newBeams;
            y++;
        }
        
        return new PuzzleResult(splitCount, "10482c1ae04bcd37818ff193c2d01562");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var beam = grid.FindAddresses(Start).First();
        var timelineCount = CountTimelines(beam, grid, []);
        
        return new PuzzleResult(timelineCount, "624e84121647191ef2c3da13286b605a");
    }

    private static long CountTimelines(Coord beam, Grid<char> grid, Dictionary<Coord, long> cache)
    {
        if (cache.TryGetValue(beam, out var count))
            return count;
        
        if (beam.Y == grid.YMax)
            return 1;
        
        var nextPos = new Coord(beam.X, beam.Y + 1);
        count = grid.ReadValueAt(nextPos) != Splitter
            ? CountTimelines(nextPos, grid, cache)
            : CountTimelines(new Coord(nextPos.X - 1, nextPos.Y), grid, cache) +
              CountTimelines(new Coord(nextPos.X + 1, nextPos.Y), grid, cache);
        
        cache.Add(beam, count);
        return count;
    }
}