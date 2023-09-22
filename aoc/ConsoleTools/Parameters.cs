using System.Collections.Generic;
using common.Parameters;

namespace Aoc.ConsoleTools;

public class Parameters
{
    public string? Id { get; }
    public int? Year { get; }
    public bool RunSlowOnly { get; }
    public bool RunCommentedOnly { get; }
    public bool RunFunOnly { get; }
    public bool ShowHelp { get; }


    public Parameters(string? id = null, int? year = null, bool runSlowOnly = false, bool runCommentedOnly = false, bool runFunOnly = false, bool showHelp = false)
    {
        Id = id;
        Year = year;
        RunSlowOnly = runSlowOnly;
        RunCommentedOnly = runCommentedOnly;
        RunFunOnly = runFunOnly;
        ShowHelp = showHelp;
    }

    public static Parameters Parse(IEnumerable<string> args)
    {
        var parser = new ParameterParser(args);
        var id = parser.GetValue("-i", "--id");
        var year = parser.GetIntValue("-y", "--year");
        var runSlow = parser.GetBoolValue("-s", "--slow") ?? false;
        var runCommented = parser.GetBoolValue("-c", "--comment") ?? false;
        var runFun = parser.GetBoolValue("-f", "--fun") ?? false;
        var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

        return new Parameters(id, year, runSlow, runCommented, runFun, showHelp);
    }

    public static Parameters Parse(string args)
    {
        return Parse(args.Split(' '));
    }
}