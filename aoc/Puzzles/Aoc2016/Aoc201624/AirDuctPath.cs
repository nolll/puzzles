namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201624;

public class AirDuctPath
{
    public int StepCount { get; }
    public AirDuctLocation Target { get; }

    public AirDuctPath(AirDuctLocation target, int stepCount)
    {
        Target = target;
        StepCount = stepCount;
    }
}