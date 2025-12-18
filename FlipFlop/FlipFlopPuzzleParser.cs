namespace Pzl.FlipFlop;

public static class FlipFlopPuzzleParser
{
    public static (int year, int day) GetPuzzleId(Type t)
    {
        var year = int.Parse(t.Name.Substring(8, 4));
        var day = int.Parse(t.Name.Substring(12, 2).TrimStart('0'));
        
        return (year, day);
    }
}