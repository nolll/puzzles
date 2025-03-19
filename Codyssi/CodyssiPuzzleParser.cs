namespace Pzl.Codyssi;

public static class CodyssiPuzzleParser
{
    public static int GetPuzzleId(Type t)
    {
        var s = t.Name.Substring(7, 2).TrimStart('0');
        if (s.Length == 0)
            s = "0";

        return int.Parse(s);
    }
}