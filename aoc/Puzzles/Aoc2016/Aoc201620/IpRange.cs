using System;

namespace Aoc.Puzzles.Aoc2016.Aoc201620;

public class IpRange
{
    public long Start { get; }
    public long End { get; }
    public long Length => End - Start + 1;
        
    public IpRange(long start, long end)
    {
        Start = start;
        End = end;
    }

    public bool IsInRange(long ip)
    {
        return ip >= Start && ip <= End;
    }

    public bool IsOverlapping(IpRange other)
    {
        return Start < other.End && other.Start < End;
    }

    protected bool Equals(IpRange other)
    {
        return Start == other.Start && End == other.End;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }
}