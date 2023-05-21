using System;
using Aoc.Platform;
using Spectre.Console;

namespace Aoc.Printing;

public class SpectreMultiDayPrinter : SpectreDayPrinter
{
    private readonly int _timeout;
    private const int CommentLength = 24;

    public SpectreMultiDayPrinter(int? timeout = null)
    {
        _timeout = timeout ?? 0;
    }
    
    public void PrintFooter()
    {
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
    }
}