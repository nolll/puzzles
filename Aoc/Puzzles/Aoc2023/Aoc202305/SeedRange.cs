namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202305;

public record SeedRange(long Start, long End)
{
    public bool IsInRange(long input) 
        => input >= Start && input < End;
}