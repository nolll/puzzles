using Common;

namespace Euler;

public class EulerProgram
{
    private const string DebugPuzzle = "1";

    static void Main(string[] args)
    {
        var program = new Program(
            new EulerPuzzleRepository(),
            new EulerHelpPrinter());
        
        program.Run(args, DebugPuzzle);
    }
}