using Spectre.Console;

namespace Pzl.Cli;

public class HelpPrinter
{
    private const string HelpText = """
                                    My solutions to Advent of Code, AquaQ Challenge and Project Euler.
                                    https://github.com/nolll/puzzles

                                    Usage:
                                    dotnet run -- [parameters]

                                    -t    --tags      comma-separated list of tags to filter puzzles
                                                      examples:
                                                      --tags aoc,2022 (runs all 2022 aoc puzzles)
                                                      --tags aquaq (runs all aquaq puzzles)
                                                      --tags euler,4 (runs euler puzzle 4)

                                    -s    --search    search query. Use quotes if the query contains spaces

                                    -h    --help      display this help text


                                    """;

    public void Print() => AnsiConsole.WriteLine(HelpText);
}