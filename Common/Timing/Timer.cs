using System;

namespace Aoc.Common.Timing;

public class Timer
{
    public DateTime StartTime { get; }

    public Timer()
    {
        StartTime = DateTime.Now;
    }

    public TimeSpan FromStart => DateTime.Now - StartTime;
}