using System.Drawing;

namespace Euler.Platform;

public abstract class SingleProblemRunner
{
    protected static readonly TimeSpan ProgressWaitTime = TimeSpan.FromMilliseconds(20);
    protected static string MarkupColor(string? s, Color color) => $"[{color.Name}]{s}[/]";
}