using AquaQ.ConsoleTools;
using AquaQ.Platform;
using AquaQ.Puzzles;
using common.Runners;

namespace AquaQ;

public class Program
{
    private const int ChallengeTimeout = 10;
    private const int DebugChallenge = 4;

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
        if (parameters.ChallengeId != null)
            RunSingle(parameters);
        else
            RunAll(parameters);
    }

    private static void RunSingle(Parameters parameters)
    {
        var challenge = AquaqPuzzleRepository.GetChallenge(parameters.ChallengeId);

        if (challenge == null)
            throw new Exception($"The specified challenge could not be found ({parameters.ChallengeId})");

        Runner.Run(challenge);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allChallenges = AquaqPuzzleRepository.GetAll();
        var filteredChallenges = new ChallengeFilter(parameters).Filter(allChallenges);
        Runner.Run(filteredChallenges);
    }

    private static void ShowHelp()
    {
        HelpPrinter.Print();
    }

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(challengeId: DebugChallenge);
#else
        return Parameters.Parse(args);
#endif
    }
}