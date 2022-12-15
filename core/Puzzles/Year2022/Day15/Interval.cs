using System.Diagnostics;

namespace Core.Puzzles.Year2022.Day15;

[DebuggerDisplay("{Start},{End}")]
public class Interval
{
    public int Start { get; }
    public int End { get; set; }

    public Interval(int start, int end)
    {
        Start = start;
        End = end;
    }
}