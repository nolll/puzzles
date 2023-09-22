using AquaQ.ConsoleTools;
using AquaQ.Platform;
using AquaQ.Puzzles;
using common.Puzzles;
using common.Runners;

namespace AquaQ;

public class Program
{
    private const int ChallengeTimeout = 10;
    private const string DebugPuzzle = "4";

    private static readonly PuzzleRunner Runner = new(ChallengeTimeout);
    private static readonly AquaqPuzzleRepository AquaqPuzzleRepository = new();
    
    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            ShowHelp();
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
        var challenge = AquaqPuzzleRepository.GetPuzzle(id);

        if (challenge == null)
            throw new Exception($"The specified challenge could not be found ({id})");

        Runner.Run(challenge);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allChallenges = AquaqPuzzleRepository.GetPuzzles();
        var filteredChallenges = new PuzzleFilter(parameters).Filter(allChallenges);
        Runner.Run(filteredChallenges);
    }

    private static void ShowHelp()
    {
        AquaqHelpPrinter.Print();
    }

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(id: DebugPuzzle);
#else
        return Parameters.Parse(args);
#endif
    }
}