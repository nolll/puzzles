using Common.Puzzles;
using Spectre.Console;

namespace AquaQ.ConsoleTools;

public class AquaqHelpPrinter : IHelpPrinter
{
    public void Print()
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