using Spectre.Console;

namespace Aoc.Printing;

public static class AocHelpPrinter
{
    public static void Print()
    {
        AnsiConsole.WriteLine("My solutions to Advent of Code.");
        AnsiConsole.WriteLine("https://github.com/nolll/puzzles/aoc");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Usage dotnet run -- [parameters]");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-p    --puzzle    the puzzle to run");
        AnsiConsole.WriteLine("-t    --tags      comma-separated list of tags to filter puzzles");
        AnsiConsole.WriteLine("-h    --help      display this help text");
        AnsiConsole.WriteLine("");
    }
}