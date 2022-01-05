namespace Core.Puzzles.Year2016.Day21;

public class RotateRightInstruction : RotateInstruction
{
    private readonly int _steps;

    public RotateRightInstruction(int steps)
    {
        _steps = steps;
    }

    public override string Run(string s)
    {
        return RotateRight(s, _steps);
    }

    public override string RunBackwards(string s)
    {
        return RotateLeft(s, _steps);
    }
}