namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202305;

public record Range(long Destination, long Source, long Length)
{
    public bool IsInRange(long input) 
        => input >= Source && input < Source + Length;

    public bool IsInRangeBackwards(long input) 
        => input >= Destination && input < Destination + Length;
};