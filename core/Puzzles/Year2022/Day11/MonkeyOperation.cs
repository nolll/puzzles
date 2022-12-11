namespace Core.Puzzles.Year2022.Day11;

public class MonkeyOperation
{
    private readonly string _op;
    private readonly string _right;

    public MonkeyOperation(string op, string right)
    {
        _op = op;
        _right = right;
    }

    public long Calc(long val)
    {
        var right = _right == "old" ? val : long.Parse(_right);
        if (_op == "+")
            return val + right;
        return val * right;
    }
}