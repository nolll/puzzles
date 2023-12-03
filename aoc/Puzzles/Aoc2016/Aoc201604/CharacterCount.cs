namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201604;

public class CharacterCount
{
    public char C { get; }
    public int Count { get; private set; }

    public CharacterCount(char c)
    {
        C = c;
        Count = 0;
    }

    public void Increment()
    {
        Count += 1;
    }
}