using System;

namespace Aoc.Puzzles.Aoc2019.Day03;

public class UnknownDirectionException : Exception
{
    public UnknownDirectionException(char direction)
        : base($"Unknown direction: {direction}")
    {
    }
}