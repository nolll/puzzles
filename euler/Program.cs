using Euler.ConsoleTools;
using Euler.Platform;
using Euler.Problems;

namespace Euler;

public class Program
{
    private const int ProblemTimeout = 10;
    private const int DebugProblem = 42;

    private static readonly ProblemRunner Runner = new(ProblemTimeout);
    private static readonly ProblemRepository ProblemRepository = new();

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
        if (parameters.ProblemId != null)
            RunSingle(parameters);
        else
            RunAll(parameters);
    }

    private static void RunSingle(Parameters parameters)
    {
        var problem = ProblemRepository.GetProblem(parameters.ProblemId);

        if (problem == null)
            throw new Exception($"The specified problem could not be found ({parameters.ProblemId})");

        Runner.Run(problem);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allProblems = ProblemRepository.GetAll();
        var filteredProblems = new ProblemFilter(parameters).Filter(allProblems);
        Runner.Run(filteredProblems);
    }

    private static void ShowHelp()
    {
        HelpPrinter.Print();
    }

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(problemId: DebugProblem);
#else
        return Parameters.Parse(args);
#endif
    }
}