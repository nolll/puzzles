using System;
using Aoc.Platform;
using Spectre.Console;

namespace Aoc.Printing;

public class SpectreMultiDayPrinter : SpectreDayPrinter, IMultiDayPrinter
{
    private readonly int _timeout;
    private const int CommentLength = 24;

    public SpectreMultiDayPrinter(int? timeout = null)
    {
        _timeout = timeout ?? 0;
    }

    public void PrintHeader()
    {
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.WriteLine("| day         | part 1     | part 2     | comment                  |");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
    }

    public void PrintDay(DayResult dayResult)
    {
        var day = dayResult.Day.Day.ToString().PadLeft(2, '0');
        var dayAndYear = $"Day {day} {dayResult.Day.Year}";
        var p1 = GetTableResult(dayResult.Result1).PadRight(10, ' ');
        var p1Color = GetColor(dayResult.Result1);
        var p2 = GetTableResult(dayResult.Result2).PadRight(10, ' ');
        var p2Color = GetColor(dayResult.Result2);
        var comment = dayResult.Comment.Length > (CommentLength - 3)
            ? dayResult.Comment.Substring(0, CommentLength - 3) + "..."
            : dayResult.Comment;
        var paddedComment = comment.PadRight(CommentLength, ' ');

        AnsiConsole.MarkupLine($"| {dayAndYear} | [{p1Color}]{p1}[/] | [{p2Color}]{p2}[/] | [yellow]{paddedComment}[/] |");
    }

    private string GetTableResult(TimedPuzzleResult result)
    {
        if (result.Status == PuzzleResultStatus.Empty)
            return "";

        if (result.Status == PuzzleResultStatus.Failed)
            return "failed";

        if (result.Status == PuzzleResultStatus.Missing)
            return "missing";

        var timeTaken = result.Status == PuzzleResultStatus.Timeout
            ? TimeSpan.FromSeconds(_timeout)
            : result.TimeTaken;

        var formattedTime = Formatter.FormatTime(timeTaken);

        return result.Status == PuzzleResultStatus.Timeout
            ? $">{formattedTime}"
            : formattedTime;
    }

    public void PrintFooter()
    {
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
    }
}