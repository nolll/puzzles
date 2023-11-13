namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202211;

public class MonkeyOperation
{
    public string Op { get; }
    public string Right { get; }

    public MonkeyOperation(string op, string right)
    {
        Op = op;
        Right = right;
    }
}