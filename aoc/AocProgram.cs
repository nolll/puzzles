using Common;

namespace Aoc;

public class AocProgram
{
    static void Main(string[] args)
    {
        var program = new Program(
            new AocPuzzleRepository(),
            new AocHelpPrinter(),
            OptionsReader.Read());

        program.Run(args);
    }
}