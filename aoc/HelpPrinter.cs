using Spectre.Console;

namespace Puzzles.aoc;

public class HelpPrinter
{
    private const string HelpText = @"
My solutions to Advent of Code, AquaQ Challenge and Project Euler.
https://github.com/nolll/puzzles

Usage dotnet run -- [parameters]

-t    --tags      comma-separated list of tags to filter puzzles
                  examples:
                  dotnet run -- --tags aoc,2022 (runs all 2002 aoc puzzles)
                  dotnet run -- --tags aquaq (runs all aquaq puzzles)
                  dotnet run -- --tags euler,4 (runs euler puzzle 4)

-h    --help      display this help text

";

    public void Print() => AnsiConsole.WriteLine(HelpText);
}