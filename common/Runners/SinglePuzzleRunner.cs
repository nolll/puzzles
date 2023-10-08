using Spectre.Console;

namespace Common.Runners;

public abstract class SinglePuzzleRunner
{
    protected static readonly TimeSpan ProgressWaitTime = TimeSpan.FromMilliseconds(20);
    protected static string MarkupColor(string s, System.Drawing.Color color) => $"[{color.Name}]{s.EscapeMarkup()}[/]";
}