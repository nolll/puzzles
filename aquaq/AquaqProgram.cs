using Common;

namespace Aquaq;

public class AquaqProgram
{
    static void Main(string[] args)
    {
        var program = new Program(
            new AquaqPuzzleRepository(),
            new AquaqHelpPrinter(),
            OptionsReader.Read());

        program.Run(args);
    }
}