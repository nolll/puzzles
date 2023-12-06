namespace Pzl.Client.Parameters;

public class Parameters
{
    public List<string> Tags { get; }
    public string? Query { get; }
    public bool ShowHelp { get; }

    public Parameters(
        List<string>? tags = null,
        string? query = null,
        bool showHelp = false)
    {
        Tags = tags ?? new List<string>();
        Query = query;
        ShowHelp = showHelp;
    }

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var tags = parser.GetListValue("-t", "--tags");
        var query = parser.GetValue("-s", "--search");
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(tags, query, showHelp);
    }

    public static Parameters Parse(string args)
    {
        return Parse(args.Split(' '));
    }
}