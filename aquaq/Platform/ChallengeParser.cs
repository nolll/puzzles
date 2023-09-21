﻿namespace AquaQ.Platform;

public static class ChallengeParser
{
    public static int GetChallengeId(Type t)
    {
        var s = t.Name.Substring(5, 2).TrimStart('0');
        if (s.Length == 0)
            s = "0";

        return int.Parse(s);
    }
}