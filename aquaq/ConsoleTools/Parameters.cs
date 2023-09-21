namespace AquaQ.ConsoleTools;

public class Parameters
{
    public int? ChallengeId { get; }
    public bool RunSlowOnly { get; }
    public bool RunCommentedOnly { get; }
    public bool ShowHelp { get; }

    public Parameters(int? challengeId = null, bool runSlowOnly = false, bool runCommentedOnly = false, bool showHelp = false)
    {
        ChallengeId = challengeId;
        RunSlowOnly = runSlowOnly;
        RunCommentedOnly = runCommentedOnly;
        ShowHelp = showHelp;
    }

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var challenge = parser.GetIntValue("-c", "--challenge");
        var runSlow = parser.GetBoolValue("-s", "--slow") ?? false;
        var runCommented = parser.GetBoolValue("-n", "--notes") ?? false;
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(challenge, runSlow, runCommented, showHelp);
    }
}