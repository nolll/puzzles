namespace Euler;

public static class EulerPuzzleParser
{
    public static int GetPuzzleId(Type t) => 
        int.Parse(t.Name.Substring(7, 3).TrimStart('0'));
}