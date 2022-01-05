using System;

namespace App.Puzzles.Year2018.Day03;

public class OverlappingClaimNotFoundException : Exception
{
    public OverlappingClaimNotFoundException()
        : base("No overlapping claim was found")
    {
    }
}