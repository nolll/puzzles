using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202305;

[Name("If You Give A Seed A Fertilizer")]
[Comment("Range solution for part 2 inspired by HyperNeutrino")]
public class Aoc202305 : AocPuzzle
{
    [Puzzle("8af1efe2f5bf2d0e78873be92fcd8fff")]
    public PuzzleResult Part1(string input) => new(SolvePart1(input));
    
    [Puzzle("bd7466367c1fe654a2ec0e3f1fe3f112")]
    public PuzzleResult Part2(string input) => new(SolvePart2(input));

    public static long SolvePart1(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();
        var seeds = ParseSeeds(groups.First());
        var rangeGroups = groups.Skip(1).Select(ParseGroup).ToList();
        var locations = seeds.Select(seed => Convert(rangeGroups, seed));

        return locations.Min();
    }

    private static long Convert(List<RangeGroup> rangeGroups, long v)
    {
        foreach (var rangeGroup in rangeGroups)
        {
            foreach (var range in rangeGroup.Ranges)
            {
                if (!range.IsInRange(v))
                    continue;
                
                v = v - range.Source + range.Destination;
                break;
            }
        }

        return v;
    }

    public static long SolvePart2(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();

        var seedNumbers = ParseSeeds(groups.First());
        var rangeGroups = groups.Skip(1).Select(ParseGroup).ToList();
        var seeds = new Stack<SeedRange>();
        for (var i = 0; i < seedNumbers.Count; i += 2)
        {
            var start = seedNumbers[i];
            var length = seedNumbers[i + 1];
            seeds.Push(new SeedRange(start, start + length));
        }

        foreach (var rangeGroup in rangeGroups)
        {
            var newSeeds = new Stack<SeedRange>();
            while (seeds.Count > 0) 
            {
                var seed = seeds.Pop();
                var foundOverlap = false;
                foreach (var range in rangeGroup.Ranges)
                {
                    var overlapStart = Math.Max(seed.Start, range.Source);
                    var overlapEnd = Math.Min(seed.End, range.Source + range.Length);

                    if (overlapStart >= overlapEnd)
                        continue;

                    newSeeds.Push(new SeedRange(
                        overlapStart - range.Source + range.Destination,
                        overlapEnd - range.Source + range.Destination));

                    if (overlapStart > seed.Start)
                        seeds.Push(seed with { End = overlapStart });

                    if (seed.End > overlapEnd)
                        seeds.Push(seed with { Start = overlapEnd });

                    foundOverlap = true;
                    break;
                }

                if(!foundOverlap)
                    newSeeds.Push(new SeedRange(seed.Start, seed.End));
            }

            seeds = newSeeds;
        }

        return seeds.MinBy(o => o.Start)!.Start;
    }

    private static List<long> ParseSeeds(IEnumerable<string> firstGroup) => 
        firstGroup.First().Split(": ").Last().Split(' ').Select(long.Parse).ToList();

    private static RangeGroup ParseGroup(IList<string> group) => new(group.Skip(1).Select(ParseRange).ToList());

    private static Range ParseRange(string s)
    {
        var (destination, source, length) = s.Split(' ').Select(long.Parse).ToArray();
        return new Range(destination, source, length);
    }
}