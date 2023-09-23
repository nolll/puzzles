using Common.Parameters;

namespace Common.Puzzles;

public class Parameters
{
    public string? Id { get; }
    public List<string> Tags { get; }
    public bool ShowHelp { get; }

    public Parameters(
        string? id = null,
        List<string>? tags = null, 
        bool showHelp = false)
    {
        Id = id;
        Tags = tags ?? new List<string>();
        ShowHelp = showHelp;
    }

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var id = parser.GetValue("-p", "--puzzle");
        var tags = parser.GetListValue("-t", "--tags"); 
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(id, tags, showHelp);
    }

    public static Parameters Parse(string args)
    {
        return Parse(args.Split(' '));
    }
}