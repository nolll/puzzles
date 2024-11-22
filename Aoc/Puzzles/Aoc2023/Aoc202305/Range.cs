namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202305;

public record Range(long Destination, long Source, long Length)
{
    public bool IsInRange(long input) 
        => input >= Source && input < Source + Length;
};