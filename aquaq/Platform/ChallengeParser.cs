namespace AquaQ.Platform;

public static class ChallengeParser
{
    public static int ParseType(Type t)
    {
        var name = t.Name;
        var id = int.Parse(name.Substring(9, 2).TrimStart('0'));
        return id;
    }
}