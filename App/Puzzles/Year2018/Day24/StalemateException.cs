using System;

namespace App.Puzzles.Year2018.Day24;

public class StalemateException : Exception
{
    public StalemateException()
        : base("Stalemate!")
    {
    }
}