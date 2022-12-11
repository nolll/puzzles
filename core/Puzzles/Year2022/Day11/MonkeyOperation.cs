namespace Core.Puzzles.Year2022.Day11;

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