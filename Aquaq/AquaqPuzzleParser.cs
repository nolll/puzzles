namespace Pzl.Aquaq;

public static class AquaqPuzzleParser
{
    public static int GetPuzzleId(Type t)
    {
        var s = t.Name.Substring(5, 2).TrimStart('0');
        if (s.Length == 0)
            s = "0";

        return int.Parse(s);
    }
}