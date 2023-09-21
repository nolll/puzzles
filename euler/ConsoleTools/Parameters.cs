namespace Euler.ConsoleTools;

public class Parameters
{
    public int? ProblemId { get; }
    public bool RunSlowOnly { get; }
    public bool RunCommentedOnly { get; }
    public bool ShowHelp { get; }

    public Parameters(int? problemId = null, bool runSlowOnly = false, bool runCommentedOnly = false, bool showHelp = false)
    {
        ProblemId = problemId;
        RunSlowOnly = runSlowOnly;
        RunCommentedOnly = runCommentedOnly;
        ShowHelp = showHelp;
    }

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var problem = parser.GetIntValue("-p", "--problem");
        var runSlow = parser.GetBoolValue("-s", "--slow") ?? false;
        var runCommented = parser.GetBoolValue("-c", "--comment") ?? false;
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(problem, runSlow, runCommented, showHelp);
    }
}