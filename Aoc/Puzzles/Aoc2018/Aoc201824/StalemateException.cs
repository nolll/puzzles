namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201824;

public class StalemateException : Exception
{
    public StalemateException()
        : base("Stalemate!")
    {
    }
}