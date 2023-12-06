namespace Pzl.Cli;

public class Options
{
    public string HashSeed { get; }
    public int TimeoutSeconds { get; }
    public string DebugTags { get; }

    public Options(string? hashSeed, string? timeoutSeconds, string? debugTags)
    {
        HashSeed = hashSeed ?? string.Empty;
        TimeoutSeconds = timeoutSeconds is not null
            ? int.Parse(timeoutSeconds)
            : 10;
        DebugTags = debugTags ?? "";
    }
}