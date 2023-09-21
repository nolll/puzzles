using System.Drawing;

namespace AquaQ.Platform;

public abstract class SingleChallengeRunner
{
    protected static readonly TimeSpan ProgressWaitTime = TimeSpan.FromMilliseconds(20);
    protected static string MarkupColor(string? s, Color color) => $"[{color.Name}]{s}[/]";
}