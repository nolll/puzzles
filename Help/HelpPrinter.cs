using Spectre.Console;

namespace Pzl.Client.Help;

public class HelpPrinter
{
    private const string HelpText = """
                                    My solutions to Advent of Code, AquaQ Challenge, Project Euler, Everybody Codes and Codyssi.
                                    https://github.com/nolll/puzzles

                                    Usage:
                                    dotnet run -- [parameters]

                                    -t    --tags      comma-separated list of tags to filter puzzles
                                                      examples:
                                                      --tags aoc,2022 (runs all 2022 aoc puzzles)
                                                      --tags aquaq (runs all aquaq puzzles)
                                                      --tags ec,2024,12 (runs everybody codes event 2024 quest 12)
                                                      --tags ec,s2,1 (runs everybody codes story 2 quest 1)
                                                      --tags euler,4 (runs euler puzzle 4)
                                                      --tags codyssi,2025,15 (runs codyssi challenge 15 2025)

                                    -s    --search    search query. Searches titles, class names and comments.  
                                                      Use quotes if the query contains spaces

                                    -h    --help      display this help text


                                    """;

    public void Print() => AnsiConsole.WriteLine(HelpText);
}