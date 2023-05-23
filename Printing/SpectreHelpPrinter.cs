using Spectre.Console;

namespace Aoc.Printing;

public class SpectreHelpPrinter : IHelpPrinter
{
    public void Print()
    {
        AnsiConsole.WriteLine("My solutions to Advent of Code.");
        AnsiConsole.WriteLine("https://github.com/nolll/aoc");
        AnsiConsole.WriteLine(); 
        AnsiConsole.WriteLine("Usage dotnet run -- [-y [year]] [-d [day]]");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("If day is omitted, all days for the specified year will run.");
        AnsiConsole.WriteLine("If year is omitted, all days for all years will run.");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[yellow]-d, --day[/]       the day to run. This will be ignored if no year is specified");
        AnsiConsole.MarkupLine("[yellow]-y, --year[/]      the year to run. All puzzles for the event will run");
        AnsiConsole.MarkupLine("[yellow]-s, --slow[/]      just run days marked as slow. Can be used on all lists");
        AnsiConsole.MarkupLine("[yellow]-c, --comment[/]   just run days that has a comment. Can be used on all lists");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[yellow]-h, --help[/]      display this help text");
    }
}