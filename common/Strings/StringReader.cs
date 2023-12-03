namespace Puzzles.common.Strings;

public static class StringReader
{
    private static readonly string LineBreak = Environment.NewLine;
    private static readonly string DoubleLineBreak = $"{LineBreak}{LineBreak}";

    public static IList<string> ReadLines(string str)
    {
        return ReadLines(str, true);
    }

    public static IList<string> ReadLines(string str, bool includeEmptyLines)
    {
        var lines = str.Split(LineBreak);
        if (!includeEmptyLines)
            return lines.Where(o => o.Length > 0).ToList();

        return lines.ToList();
    }

    public static IList<IList<string>> ReadLineGroups(string str) 
        => ReadStringGroups(str).Select(ReadLines).ToList();

    public static IList<IList<string>> ReadLineGroupsWithWhiteSpace(string str) 
        => ReadStringGroupsWithWhitespace(str).Select(ReadLines).ToList();

    public static IList<string> ReadStringGroups(string str) 
        => str.Trim().Split(DoubleLineBreak).ToList();

    public static IList<string> ReadStringGroupsWithWhitespace(string str) 
        => str.Split(DoubleLineBreak).ToList();
}