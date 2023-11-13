using Spectre.Console;

namespace Puzzles.common.Runners;

public abstract class SinglePuzzleRunner
{
    protected static readonly TimeSpan ProgressWaitTime = TimeSpan.FromMilliseconds(20);
    protected static string MarkupColor(string s, Color color) => $"[{color.ToMarkup()}]{s.EscapeMarkup()}[/]";
}