using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202305;

public class Aoc202305 : AocPuzzle
{
    public override string Name => "If You Give A Seed A Fertilizer";

    protected override PuzzleResult RunPart1()
    {
        var result = SeedToLocation1(InputFile);

        return new PuzzleResult(result, "8af1efe2f5bf2d0e78873be92fcd8fff");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = SeedToLocation2(InputFile);

        return new PuzzleResult(result, "bd7466367c1fe654a2ec0e3f1fe3f112");
    }

    public static long SeedToLocation1(string input)
    {
        var almanac = new Almanac(input);

        var locations = new List<long>();
        foreach (var seed in almanac.Seeds)
        {
            locations.Add(almanac.SeedToLocation(seed));
        }

        return locations.Min();
    }

    public static long SeedToLocation2(string input)
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

public record Range(long Destination, long Source, long Length)
{
    public bool IsInRange(long input) 
        => input >= Source && input < Source + Length;

    public bool IsInRangeBackwards(long input) 
        => input >= Destination && input < Destination + Length;
};

public record SeedRange(long Start, long Length)
{
    public bool IsInRange(long input) 
        => input >= Start && input < Start + Length;
}

public class Ranges(List<Range> ranges)
{
    public long Convert(long input)
    {
        foreach (var range in ranges)
        {
            if (range.IsInRange(input))
                return input - range.Source + range.Destination;
        }

        return input;
    }

    public long ConvertBackwards(long input)
    {
        foreach (var range in ranges)
        {
            if (range.IsInRangeBackwards(input))
                return input - range.Destination + range.Source;
        }

        return input;
    }
}

public class Almanac
{
    private readonly Ranges _seedToSoil;
    private readonly Ranges _soilToFertilizer;
    private readonly Ranges _fertilizerToWater;
    private readonly Ranges _waterToLight;
    private readonly Ranges _lightToTemperature;
    private readonly Ranges _temperatureToHumidity;
    private readonly Ranges _humidityToLocation;
        
    public List<SeedRange> SeedRanges { get; }
    public IEnumerable<long> Seeds { get; }

    public Almanac(string input)
    {
        var groups = StringReader.ReadLineGroups(input);

        SeedRanges = new List<SeedRange>();
        var seedNumbers = groups[0].First().Split(": ").Last().Split(' ').Select(long.Parse).ToList();
        for (var i = 0; i < seedNumbers.Count; i += 2)
        {
            var start = seedNumbers[i];
            var length = seedNumbers[i + 1];
            SeedRanges.Add(new SeedRange(start, length));
        }

        Seeds = groups[0].First().Split(": ").Last().Split(' ').Select(long.Parse);
        _seedToSoil = ParseGroup(groups[1]);
        _soilToFertilizer = ParseGroup(groups[2]);
        _fertilizerToWater = ParseGroup(groups[3]);
        _waterToLight = ParseGroup(groups[4]);
        _lightToTemperature = ParseGroup(groups[5]);
        _temperatureToHumidity = ParseGroup(groups[6]);
        _humidityToLocation = ParseGroup(groups[7]);
    }

    public long SeedToLocation(long seed) =>
        _humidityToLocation.Convert(
            _temperatureToHumidity.Convert(
                _lightToTemperature.Convert(
                    _waterToLight.Convert(
                        _fertilizerToWater.Convert(
                            _soilToFertilizer.Convert(
                                _seedToSoil.Convert(seed)))))));

    public long LocationToSeed(long location) =>
        _seedToSoil.ConvertBackwards(
            _soilToFertilizer.ConvertBackwards(
                _fertilizerToWater.ConvertBackwards(
                    _waterToLight.ConvertBackwards(
                        _lightToTemperature.ConvertBackwards(
                            _temperatureToHumidity.ConvertBackwards(
                                _humidityToLocation.ConvertBackwards(location)))))));

    private static Ranges ParseGroup(IList<string> group)
    {
        var ranges = group.Skip(1).Select(
                o => o.Split(' ')
                    .Select(long.Parse)
                    .ToList())
            .Select(p => new Range(p[0], p[1], p[2]))
            .ToList();

        return new Ranges(ranges);
    }
}