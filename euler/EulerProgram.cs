using common.Puzzles;
using Common.Puzzles;
using common.Runners;
using Euler.ConsoleTools;
using Euler.Platform;

namespace Euler;

public class EulerProgram
{
    private const int ProblemTimeout = 10;
    private const string DebugPuzzle = "42";

    private static readonly PuzzleRunner Runner = new(ProblemTimeout);
    private static readonly IPuzzleRepository PuzzleRepository = new EulerPuzzleRepository();
    private static readonly IHelpPrinter HelpPrinter = new EulerHelpPrinter();

    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            HelpPrinter.Print();
        else
            RunProblems(parameters);
    }

    private static void RunProblems(Parameters parameters)
    {
        if (parameters.Id != null)
            RunSingle(parameters.Id);
        else
            RunAll(parameters);
    }

    private static void RunSingle(string id)
    {
        var problem = PuzzleRepository.GetPuzzle(id);

        if (problem == null)
            throw new Exception($"The specified puzzle could not be found ({id})");

        Runner.Run(problem);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allProblems = PuzzleRepository.GetPuzzles();
        var filteredProblems = new PuzzleFilter(parameters).Filter(allProblems);
        Runner.Run(filteredProblems);
    }
    
    private static Parameters ParseParameters(string[] args) =>
        DebugMode.IsDebugMode
            ? new Parameters(id: DebugPuzzle)
            : Parameters.Parse(args);
}