namespace Euler.Platform;

public static class ProblemParser
{
    public static int ParseType(Type t)
    {
        var name = t.Name;
        var id = int.Parse(name.Substring(7, 3).TrimStart('0'));
        return id;
    }
}