namespace Euler.Platform;

public static class ProblemParser
{
    public static int GetProblemId(Type t) => 
        int.Parse(t.Name.Substring(7, 3).TrimStart('0'));
}