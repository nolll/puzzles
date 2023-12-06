namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202305;

public record RangeGroup(List<Range> Ranges)
{
    public long Convert(long input)
    {
        foreach (var range in Ranges)
        {
            if (range.IsInRange(input))
                return input - range.Source + range.Destination;
        }

        return input;
    }
}