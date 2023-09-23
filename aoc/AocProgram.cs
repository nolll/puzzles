using Aoc.Puzzles;
using Common;

namespace Aoc;

public class AocProgram
{
    private const string DebugPuzzle = "201501";

    static void Main(string[] args)
    {
        var program = new Program(
            new AocPuzzleRepository(),
            new AocHelpPrinter());

        program.Run(args, DebugPuzzle);
    }
}