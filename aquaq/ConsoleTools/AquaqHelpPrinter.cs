using Spectre.Console;

namespace AquaQ.ConsoleTools;

public static class AquaqHelpPrinter
{
    public static void Print()
    {
        AnsiConsole.WriteLine("My solutions to AquaQ Challenge.");
        AnsiConsole.WriteLine("https://github.com/nolll/puzzles/aquaq");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Usage dotnet run -- [parameters]");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-p    --puzzle    the puzzle to run");
        AnsiConsole.WriteLine("-t    --tags      comma-separated list of tags to filter puzzles");
        AnsiConsole.WriteLine("-h    --help      display this help text");
        AnsiConsole.WriteLine("");
    }
}