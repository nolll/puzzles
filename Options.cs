namespace Pzl.Client;

public class Options(string? hashSeed, string? timeoutSeconds, string? debugTags)
{
    public string HashSeed { get; } = hashSeed ?? string.Empty;
    public int TimeoutSeconds { get; } = timeoutSeconds is not null
        ? int.Parse(timeoutSeconds)
        : 10;

    public string DebugTags { get; } = debugTags ?? "";
}