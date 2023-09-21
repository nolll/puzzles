namespace Aoc.Puzzles.Year2020.Day12;

public class FerryNavigationInstruction
{
    public char Direction { get; }
    public int Value { get; }

    public FerryNavigationInstruction(char direction, int value)
    {
        Direction = direction;
        Value = value;
    }

    public static FerryNavigationInstruction Parse(string s)
    {
        return new FerryNavigationInstruction(s[0], int.Parse(s.Substring(1)));
    }
}