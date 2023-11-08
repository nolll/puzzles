using Common;

namespace Euler;

public class EulerProgram
{
    static void Main(string[] args)
    {
        var program = new Program(
            new EulerPuzzleRepository(),
            new EulerHelpPrinter(),
            OptionsReader.Read());
        
        program.Run(args);
    }
}