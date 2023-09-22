using common.Puzzles;
using common.Runners;
using Euler.ConsoleTools;
using Euler.Platform;
using Euler.Problems;

namespace Euler;

public class Program
{
    private const int ProblemTimeout = 10;
    private const string DebugProblem = "42";

    private static readonly PuzzleRunner Runner = new(ProblemTimeout);
    private static readonly IPuzzleRepository EulerPuzzleRepository = new EulerPuzzleRepository();

    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            ShowHelp();
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
        var problem = EulerPuzzleRepository.GetPuzzle(id);

        if (problem == null)
            throw new Exception($"The specified problem could not be found ({id})");

        Runner.Run(problem);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allProblems = EulerPuzzleRepository.GetPuzzles();
        var filteredProblems = new PuzzleFilter(parameters).Filter(allProblems);
        Runner.Run(filteredProblems);
    }

    private static void ShowHelp()
    {
        EulerHelpPrinter.Print();
    }

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(id: DebugProblem);
#else
        return Parameters.Parse(args);
#endif
    }
}