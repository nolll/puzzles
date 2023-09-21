namespace AquaQ.Platform;

public static class ChallengeParser
{
    public static int GetChallengeId(Type t) => 
        int.Parse(t.Name.Substring(9, 2).TrimStart('0'));
}