using Spectre.Console;

namespace AquaQ.Platform;

public class MultiDayChallengeRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiDayChallengeRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<ChallengeWrapper> challenges)
    {
        var challengeList = challenges.ToList();
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine($"Running {challengeList.Count} puzzles");
        WriteDivider();
        AnsiConsole.WriteLine("| challenge    | result     | comment                  |");
        WriteDivider();

        foreach (var challenge in challengeList)
        {
            new InSequenceSingleChallengeRunner(challenge, _timeoutTimespan).Run();
        }

        WriteDivider();
        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteDivider()
    {
        AnsiConsole.WriteLine("--------------------------------------------------------");
    }
}