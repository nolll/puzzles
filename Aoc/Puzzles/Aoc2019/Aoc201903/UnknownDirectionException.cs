namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201903;

public class UnknownDirectionException : Exception
{
    public UnknownDirectionException(char direction)
        : base($"Unknown direction: {direction}")
    {
    }
}