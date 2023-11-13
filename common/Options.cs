namespace Puzzles.common;

public class Options
{
    public string HashSeed { get; }
    public int TimeoutSeconds { get; }
    public string DebugPuzzle { get; }

    public Options(string? hashSeed, string? timeoutSeconds, string? debugPuzzle)
    {
        HashSeed = hashSeed ?? string.Empty;
        TimeoutSeconds = timeoutSeconds is not null
            ? int.Parse(timeoutSeconds)
            : 10;
        DebugPuzzle = debugPuzzle ?? "1";
    }
}