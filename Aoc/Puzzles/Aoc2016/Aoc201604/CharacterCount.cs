namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

public class CharacterCount(char c)
{
    public char C { get; } = c;
    public int Count { get; private set; }

    public void Increment() => Count += 1;
}