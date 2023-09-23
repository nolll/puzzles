using AquaQ.ConsoleTools;
using AquaQ.Platform;
using common.Puzzles;
using Common.Puzzles;
using common.Runners;

namespace AquaQ;

public class AquaqProgram
{
    private const int PuzzleTimeout = 10;
    private const string DebugPuzzle = "4";

    private static readonly PuzzleRunner Runner = new(PuzzleTimeout);
    private static readonly IPuzzleRepository PuzzleRepository = new AquaqPuzzleRepository();
    private static readonly IHelpPrinter HelpPrinter = new AquaqHelpPrinter();

    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            HelpPrinter.Print();
        else
            RunChallenges(parameters);
    }

    private static void RunChallenges(Parameters parameters)
    {
        if (parameters.Id != null)
            RunSingle(parameters.Id);
        else
            RunAll(parameters);
    }

    private static void RunSingle(string id)
    {
        var challenge = PuzzleRepository.GetPuzzle(id);

        if (challenge == null)
            throw new Exception($"The specified challenge could not be found ({id})");

        Runner.Run(challenge);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allChallenges = PuzzleRepository.GetPuzzles();
        var filteredChallenges = new PuzzleFilter(parameters).Filter(allChallenges);
        Runner.Run(filteredChallenges);
    }

    private static Parameters ParseParameters(string[] args) =>
        DebugMode.IsDebugMode 
            ? new Parameters(id: DebugPuzzle) 
            : Parameters.Parse(args);
}