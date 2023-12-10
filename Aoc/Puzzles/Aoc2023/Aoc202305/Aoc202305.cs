using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202305;

[Comment("Range solution for part 2 inspired by HyperNeutrino")]
public class Aoc202305 : AocPuzzle
{
    public override string Name => "If You Give A Seed A Fertilizer";

    protected override PuzzleResult RunPart1()
    {
        var result = Part1(InputFile);

        return new PuzzleResult(result, "8af1efe2f5bf2d0e78873be92fcd8fff");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Part2(InputFile);

        return new PuzzleResult(result, "bd7466367c1fe654a2ec0e3f1fe3f112");
    }

    public static long Part1(string input)
    {
        var groups = StringReader.ReadLineGroups(input);

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
                if (range.IsInRange(v))
                {
                    v = v - range.Source + range.Destination;
                    break;
                }
            }
        }

        return v;
    }

    public static long Part2(string input)
    {
        var groups = StringReader.ReadLineGroups(input);

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
                    
                    newSeeds.Push(
                        new SeedRange(
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

    private static List<long> ParseSeeds(IEnumerable<string> firstGroup) => firstGroup.First().Split(": ").Last().Split(' ').Select(long.Parse).ToList();

    private static RangeGroup ParseGroup(IList<string> group) 
        => new(group.Skip(1).Select(ParseRange).ToList());

    private static Range ParseRange(string s)
    {
        var p = s.Split(' ').Select(long.Parse).ToList();
        var destination = p[0];
        var source = p[1];
        var length = p[2];
        return new Range(destination, source, length);
    }
}