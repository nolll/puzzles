namespace Pzl.Codyssi;

public static class CodyssiPuzzleParser
{
    public static (int year, int day) GetPuzzleId(Type t)
    {
        var year = int.Parse(t.Name.Substring(7, 4));
        var day = int.Parse(t.Name.Substring(11, 2).TrimStart('0'));
        
        return (year, day);
    }
}