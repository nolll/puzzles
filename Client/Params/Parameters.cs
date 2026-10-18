namespace Pzl.Client.Params;

public record Parameters(
    string[] Tags,
    string? Query,
    bool ShowHelp,
    bool ShowMetrics)
{
    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var tags = parser.GetListValue("-t", "--tags");
        var query = parser.GetValue("-s", "--search");
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;
        var showMetrics = parser.GetBoolValue("-m", "--metrics") ?? false;

        return new Parameters(tags, query, showHelp, showMetrics);
    }

    public static Parameters Parse(string args) => Parse(args.Split(' '));
    public static Parameters Create(string[] tags, string? query = null, bool showHelp = false, bool showMetrics = false) => 
        new(tags, query, showHelp, showMetrics);
}
