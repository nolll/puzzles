namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201621;

public class RotateLeftInstruction : RotateInstruction
{
    private readonly int _steps;

    public RotateLeftInstruction(int steps)
    {
        _steps = steps;
    }

    public override string Run(string s)
    {
        return RotateLeft(s, _steps);
    }

    public override string RunBackwards(string s)
    {
        return RotateRight(s, _steps);
    }
}