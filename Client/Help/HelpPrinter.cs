using Pzl.Client.Running.Runners;

namespace Pzl.Client.Help;

public class HelpPrinter
{
    private const string HelpText = """
                                    My solutions to programming challenges.
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
                                                      --tags ff,2025,3 (runs flipflop puzzle 3 2025)

                                    -s    --search    search query. Searches titles, class names and comments.  
                                                      Use quotes if the query contains spaces

                                    -h    --help      display this help text
                                    """;

    public void Print()
    {
        Printer.WriteLine(HelpText);
        Printer.WriteLine();
        // Printer.WriteLine("Links:");
        // Printer.MarkupLine("[blue underline link=https://adventofcode.com]Advent of Code[/]");
        // Printer.WriteLine("AquaQ Challenge: https://challenges.aquaq.co.uk");
        // Printer.WriteLine("Codyssi: https://www.codyssi.com");
        // Printer.WriteLine("FlipFlop: https://flipflop.slome.org");
        // Printer.WriteLine("Everybody Codes: https://everybody.codes");
        // Printer.WriteLine("Project Euler: https://projecteuler.net");
        // Printer.WriteLine();
    }
}