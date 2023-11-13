using System.Diagnostics;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202215;

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