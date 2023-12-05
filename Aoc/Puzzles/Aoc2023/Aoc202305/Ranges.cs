namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202305;

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