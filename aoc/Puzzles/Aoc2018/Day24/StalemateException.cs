using System;

namespace Aoc.Puzzles.Aoc2018.Day24;

public class StalemateException : Exception
{
    public StalemateException()
        : base("Stalemate!")
    {
    }
}