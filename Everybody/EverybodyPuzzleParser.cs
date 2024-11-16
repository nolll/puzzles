namespace Pzl.Everybody;

public static class EverybodyPuzzleParser
{
    public static int GetPuzzleId(Type t)
    {
        var s = t.Name.Substring(9, 2).TrimStart('0');
        if (s.Length == 0)
            s = "0";

        return int.Parse(s);
    }
}