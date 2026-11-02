namespace Pzl.Tools.Computers.IntCode;

public static class MemoryParser
{
    public static IList<long> Parse(string input) => [.. input.Trim().Split(',').Select(long.Parse)];
}