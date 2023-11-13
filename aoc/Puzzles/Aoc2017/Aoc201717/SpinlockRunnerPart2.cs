namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201717;

public class SpinlockRunnerPart2
{
    private readonly int _steps;
    public int SecondValue { get; private set; }

    public SpinlockRunnerPart2(int steps)
    {
        _steps = steps;
        SecondValue = 0;
    }

    public void Run(int target)
    {
        var v = 1;
        var pos = 0;
        while (v <= target)
        {
            pos += _steps;
            while (pos > v - 1) 
                pos -= v;

            if (pos == 0)
                SecondValue = v;
            pos++;
            v++;
        }
    }
}