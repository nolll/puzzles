namespace Pzl.Tools.Strings;

public static class StringReader
{
    public static IList<string> ReadLines(string str) => 
        ReadLines(str, true);

    public static IList<string> ReadLines(string str, bool includeEmptyLines)
    {
        var lines = str.Split(LineBreaks.Single);
        return !includeEmptyLines 
            ? lines.Where(o => o.Length > 0).ToList() 
            : lines.ToList();
    }

    public static IList<IList<string>> ReadLineGroups(string str) => 
        ReadStringGroups(str).Select(ReadLines).ToList();

    public static IList<IList<string>> ReadLineGroupsWithWhiteSpace(string str) => 
        ReadStringGroupsWithWhitespace(str).Select(ReadLines).ToList();

    public static IList<string> ReadStringGroups(string str) => 
        str.Trim().Split(LineBreaks.Double).ToList();

    public static IList<string> ReadStringGroupsWithWhitespace(string str) => 
        str.Split(LineBreaks.Double).ToList();
}