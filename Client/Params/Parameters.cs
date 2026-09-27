namespace Pzl.Client.Params;

public class Parameters(
    string[]? tags = null,
    string? query = null,
    bool showHelp = false)
{
    public string[] Tags { get; } = tags ?? [];
    public string? Query { get; } = query;
    public bool ShowHelp { get; } = showHelp;

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var tags = parser.GetListValue("-t", "--tags");
        var query = parser.GetValue("-s", "--search");
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(tags, query, showHelp);
    }

    public static Parameters Parse(string args) => Parse(args.Split(' '));
}