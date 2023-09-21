using System;
using Spectre.Console;

namespace Aoc.Platform;

public abstract class SinglePuzzleRunner
{
    protected static readonly TimeSpan ProgressWaitTime = TimeSpan.FromMilliseconds(20);
    protected static string MarkupColor(string s, Color color) => $"[{color}]{s}[/]";
}