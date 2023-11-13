using Puzzles.aoc;
using Puzzles.common;

namespace Puzzles;

public class Program
{
    static void Main(string[] args)
    {
        var program = new PuzzleProgram(
            new PuzzleRepository(),
            new AocHelpPrinter(),
            OptionsReader.Read());

        program.Run(args);
    }

}