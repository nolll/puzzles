using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202305;

public class Aoc202305 : AocPuzzle
{
    public override string Name => "If You Give A Seed A Fertilizer";
    public override bool IsSlow => true;

    protected override PuzzleResult RunPart1()
    {
        var result = SeedToLocation(InputFile);

        return new PuzzleResult(result, "8af1efe2f5bf2d0e78873be92fcd8fff");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = LocationToSeed(InputFile);

        return new PuzzleResult(result, "bd7466367c1fe654a2ec0e3f1fe3f112");
    }

    public static long SeedToLocation(string input)
    {
        var almanac = new Almanac(input);

        var locations = new List<long>();
        foreach (var seed in almanac.Seeds)
        {
            locations.Add(almanac.SeedToLocation(seed));
        }

        return locations.Min();
    }

    public static long LocationToSeed(string input)
    {
        var almanac = new Almanac(input);

        var location = 0L;

        while (true)
        {
            var seed = almanac.LocationToSeed(location);
            if (almanac.SeedRanges.Any(o => o.IsInRange(seed)))
                return location;
            
            location++;
        }
    }
}